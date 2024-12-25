class Program
{
    static void Main(string[] args)
    {
        ChatServer server = new ChatServer(8888);
        server.Start();
    }
}
