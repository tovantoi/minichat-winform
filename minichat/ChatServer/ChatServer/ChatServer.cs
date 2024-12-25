using System.Net;
using System.Net.Sockets;
using System.Text;

public class ChatServer
{
    private TcpListener _server;
    private List<(TcpClient Client, string Username)> _clients = new List<(TcpClient, string)>();
    private Dictionary<string, List<string>> _groups = new Dictionary<string, List<string>>();

    private Dictionary<string, User> _users = new Dictionary<string, User>
    {
        { "user1", new User("user1", "123") },
        { "user2", new User("user2", "123") },
        { "user3", new User("user3", "123") }
    };

    public ChatServer(int port)
    {
        _server = new TcpListener(IPAddress.Any, port);
    }

    public void Start()
    {
        _server.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            var client = _server.AcceptTcpClient();
            Thread clientThread = new Thread(() => HandleClient(client));
            clientThread.Start();
        }
    }

  private void HandleClient(TcpClient client)
{
    var stream = client.GetStream();
    byte[] buffer = new byte[1024];

    int bytesRead = stream.Read(buffer, 0, buffer.Length);
    string loginInfo = Encoding.UTF8.GetString(buffer, 0, bytesRead);
    string[] loginParts = loginInfo.Split(':');

    if (loginParts.Length != 2)
    {
        SendToClient(stream, "Đăng nhập thất bại!");
        client.Close();
        return;
    }

    string username = loginParts[0];
    string password = loginParts[1];

    if (_users.TryGetValue(username, out User user) && user.Password == password)
    {
        SendToClient(stream, "Login successful!");

        _clients.Add((client, username));
        Console.WriteLine($"{username} đã tham gia trò chuyện.");
        BroadcastMessage($"{username} đã tham gia trò chuyện.", username);

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            if (message.StartsWith("/create-group"))
            {
                HandleCreateGroup(message, username, stream);
            }
            else if (message.StartsWith("/add-to-group"))
            {
                HandleAddToGroup(message, username, stream);
            }
            else if (message.StartsWith("/group-msg"))
            {
                HandleGroupMessage(message, username);
            }
            else if (message.StartsWith("/private"))
            {
                HandlePrivateMessage(message, username);
            }
            else
            {
                BroadcastMessage($"{username}: {message}", username);
            }
        }

        _clients.RemoveAll(c => c.Client == client);
        Console.WriteLine($"{username} đã thoát.");
        BroadcastMessage($"{username} đã thoát.", username);
        client.Close();
    }
    else
    {
        SendToClient(stream, "Đăng nhập thất bại!");
        client.Close();
    }
}

private void HandleCreateGroup(string message, string username, NetworkStream stream)
{
    string[] parts = message.Split(' ');
    if (parts.Length >= 2)
    {
        string groupName = parts[1];
        if (!_groups.ContainsKey(groupName))
        {
            _groups[groupName] = new List<string> { username };
            SendToClient(stream, $"Group '{groupName}' created and you have been added.");
        }
        else
        {
            SendToClient(stream, $"Group '{groupName}' already exists.");
        }
    }
}

private void HandleAddToGroup(string message, string username, NetworkStream stream)
{
    string[] parts = message.Split(' ');
    if (parts.Length >= 3)
    {
        string groupName = parts[1];
        string userToAdd = parts[2];

        if (_groups.ContainsKey(groupName) && _clients.Exists(c => c.Username == userToAdd))
        {
            if (!_groups[groupName].Contains(userToAdd))
            {
                _groups[groupName].Add(userToAdd);
                SendToClient(stream, $"{userToAdd} has been added to group '{groupName}'.");
            }
            else
            {
                SendToClient(stream, $"{userToAdd} is already in group '{groupName}'.");
            }
        }
        else
        {
            SendToClient(stream, $"Group '{groupName}' does not exist or user '{userToAdd}' not found.");
        }
    }
}

    private void HandleGroupMessage(string message, string username)
    {
        string[] parts = message.Split(' ', 3);
        if (parts.Length >= 3)
        {
            string groupName = parts[1];
            string groupMessage = parts[2];

            // Kiểm tra xem nhóm có tồn tại và người gửi có trong nhóm
            if (_groups.ContainsKey(groupName) && _groups[groupName].Contains(username))
            {
                foreach (var member in _groups[groupName])
                {
                    var recipient = _clients.Find(c => c.Username == member);
                    if (recipient.Client != null && recipient.Username != username) // Không gửi lại cho người gửi
                    {
                        SendToClient(recipient.Client.GetStream(), $"[{groupName}] {username}: {groupMessage}");
                    }
                }
            }
            else
            {
                // Nếu nhóm không tồn tại hoặc người gửi không thuộc nhóm, bỏ qua
                Console.WriteLine($"Người dùng {username} không có quyền gửi tin nhắn tới nhóm '{groupName}'");
            }
        }
    }


    private void HandlePrivateMessage(string message, string username)
{
    string[] parts = message.Split(' ', 3);
    if (parts.Length >= 3)
    {
        string recipientName = parts[1];
        string privateMessage = parts[2];

        var recipient = _clients.Find(c => c.Username == recipientName);
        if (recipient.Client != null)
        {
            SendToClient(recipient.Client.GetStream(), $"(Private) {username}: {privateMessage}");
        }
    }
}


    private void SendToClient(NetworkStream stream, string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        stream.Write(buffer, 0, buffer.Length);
    }
    private void BroadcastMessage(string message, string senderUsername)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        foreach (var (client, username) in _clients)
        {
            if (username != senderUsername)
            {
                var stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }

    private void SendPrivateMessage(string message, string recipientUsername)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        var recipient = _clients.Find(c => c.Username == recipientUsername);

        if (recipient.Client != null)
        {
            var stream = recipient.Client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
