using System.Net.Sockets;
using System.Text;

namespace ChatApp
{
    public partial class Form1 : Form
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private bool isPasswordVisible = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                _client = new TcpClient("127.0.0.1", 8888);
                _stream = _client.GetStream();

                // Gửi thông tin đăng nhập
                string loginInfo = $"{username}:{password}";
                byte[] buffer = Encoding.UTF8.GetBytes(loginInfo);
                _stream.Write(buffer, 0, buffer.Length);

                // Nhận phản hồi từ server
                buffer = new byte[1024];
                int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (response.Contains("Login successful"))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    StartReceivingMessages();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                    Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
            }
        }
        private void StartReceivingMessages()
        {
            var receiveThread = new System.Threading.Thread(() =>
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int bytesRead = _stream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            Invoke(new Action(() =>
                            {
                                rtbChat.AppendText(message + Environment.NewLine);
                                rtbChat.ScrollToCaret();
                            }));
                        }
                    }
                }
                catch
                {
                    Disconnect();
                }
            });
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void SendMessage(string message)
        {
            if (_stream != null && !string.IsNullOrWhiteSpace(message))
            {
                try
                {
                    // Hiển thị tin nhắn của mình trước khi gửi
                    rtbChat.AppendText($"Me: {message}{Environment.NewLine}");
                    rtbChat.ScrollToCaret();

                    // Gửi tin nhắn đến server
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    _stream.Write(buffer, 0, buffer.Length);

                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi gửi tin nhắn: {ex.Message}");
                }
            }
        }
        private void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
            MessageBox.Show("Đã ngắt kết nối.");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text; // Tên nhóm
            string message = txtMessage.Text; // Tin nhắn

            if (!string.IsNullOrWhiteSpace(groupName) && !string.IsNullOrWhiteSpace(message))
            {
                // Kiểm tra xem người dùng có nhập tên nhóm không
                SendMessage($"/group-msg {groupName} {message}"); // Gửi tin nhắn nhóm
            }
            else if (!string.IsNullOrWhiteSpace(message))
            {
                // Nếu không có nhóm nhưng có tin nhắn, gửi tin nhắn cá nhân
                SendMessage(message); // Gửi tin nhắn cá nhân
            }
            else
            {
                // Nếu không có tin nhắn hoặc nhóm, thông báo lỗi hoặc yêu cầu nhập lại
                MessageBox.Show("Please enter a message or select a group to send to.");
            }
        }

        private void btnPrivateMessage_Click(object sender, EventArgs e)
        {
            string recipient = txtRecipient.Text;
            string message = txtMessage.Text;

            if (!string.IsNullOrWhiteSpace(recipient) && !string.IsNullOrWhiteSpace(message))
            {
                SendMessage($"/private {recipient} {message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                // Nếu mật khẩu đang hiện, chuyển về ẩn
                txtPassword.PasswordChar = '*';
            }
            else
            {
                // Nếu mật khẩu đang ẩn, chuyển về hiện
                txtPassword.PasswordChar = '\0'; // Không hiển thị ký tự nào (hiển thị mật khẩu thực)
            }

            // Chuyển đổi trạng thái
            isPasswordVisible = !isPasswordVisible;
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;

            if (!string.IsNullOrWhiteSpace(groupName))
            {
                SendMessage($"/create-group {groupName}");
            }
        }

        private void btnAddToGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            string userToAdd = txtRecipient.Text;

            if (!string.IsNullOrWhiteSpace(groupName) && !string.IsNullOrWhiteSpace(userToAdd))
            {
                SendMessage($"/add-to-group {groupName} {userToAdd}");
            }
        }
    }
}
