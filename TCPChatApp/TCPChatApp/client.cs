using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TCPClient
{
    static TcpClient client;
    static NetworkStream stream;

    static void Main()
    {
        client = new TcpClient("127.0.0.1", 5000);
        stream = client.GetStream();
        Console.WriteLine("Connected to the server. Type messages and press Enter to send.");

        // Start receiving messages in a separate thread
        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Sending messages in the main thread
        while (true)
        {
            string message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);

            if (message.ToLower() == "exit")
            {
                Console.WriteLine("Closing connection...");
                break;
            }
        }

        client.Close();
    }

    static void ReceiveMessages()
    {
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("\nServer: " + message);
                Console.Write("You: ");
            }
        }
        catch
        {
            Console.WriteLine("Server disconnected.");
        }
    }
}
