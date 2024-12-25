using System.Net.Sockets;
using System.Text;

public class ChatClient
{
    private TcpClient _client;
    private NetworkStream _stream;
    private string _username;

    public ChatClient(string ip, int port, string username, string password)
    {
        try
        {
            _client = new TcpClient(ip, port);
            _stream = _client.GetStream();
            _username = username;

            // Gửi thông tin đăng nhập đến server
            string loginInfo = $"{username}:{password}";
            byte[] buffer = Encoding.UTF8.GetBytes(loginInfo);
            _stream.Write(buffer, 0, buffer.Length);

            // Đọc phản hồi từ server
            buffer = new byte[1024];
            int bytesRead = _stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            if (response == "Đăng nhập thất bại!")
            {
                Console.WriteLine(response);
                Disconnect();
                return;
            }

            Console.WriteLine("Đăng nhập thành công! Bạn có thể bắt đầu trò chuyện.");
            StartReceivingMessages();
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Error connecting to server: {ex.Message}");
        }
    }

    private void StartReceivingMessages()
    {
        Thread receiveThread = new Thread(() =>
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = _stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
            }
        });
        receiveThread.IsBackground = true; // Đặt thread ở chế độ nền
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine();
            SendMessage(message);
        }
    }

    private void SendMessage(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            return; // Không gửi tin nhắn rỗng
        }

        byte[] buffer = Encoding.UTF8.GetBytes(message);
        _stream.Write(buffer, 0, buffer.Length);
    }

    private void Disconnect()
    {
        _stream.Close();
        _client.Close();
        Console.WriteLine("Disconnected from server.");
    }
}
