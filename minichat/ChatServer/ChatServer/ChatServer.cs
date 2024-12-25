using System.Net;
using System.Net.Sockets;
using System.Text;

public class ChatServer
{
    private TcpListener _server;
    private List<(TcpClient Client, string Username)> _clients = new List<(TcpClient, string)>();

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
            byte[] failMessage = Encoding.UTF8.GetBytes("Đăng nhập thất bại!");
            stream.Write(failMessage, 0, failMessage.Length);
            client.Close();
            return;
        }

        string username = loginParts[0];
        string password = loginParts[1];

        if (_users.TryGetValue(username, out User user) && user.Password == password)
        {
            // Gửi thông báo đăng nhập thành công
            byte[] successMessage = Encoding.UTF8.GetBytes("Login successful!");
            stream.Write(successMessage, 0, successMessage.Length);

            _clients.Add((client, username));
            Console.WriteLine($"{username} đã tham gia trò chuyện.");
            BroadcastMessage($"{username} đã tham gia trò chuyện.", username);

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (message.StartsWith("/private"))
                {
                    string[] messageParts = message.Split(' ', 3);
                    if (messageParts.Length >= 3)
                    {
                        string recipient = messageParts[1];
                        string privateMessage = messageParts[2];
                        SendPrivateMessage($"{username} (Private): {privateMessage}", recipient);
                    }
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
            byte[] failMessage = Encoding.UTF8.GetBytes("Đăng nhập thất bại!");
            stream.Write(failMessage, 0, failMessage.Length);
            client.Close();
        }
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
