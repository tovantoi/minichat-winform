class Program
{
    static void Main(string[] args)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        ChatClient client = new ChatClient("127.0.0.1", 8888, username, password);
    }
}
