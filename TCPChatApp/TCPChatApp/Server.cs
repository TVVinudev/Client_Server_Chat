using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class TCPServer
{
    static TcpClient client;
    static NetworkStream stream;

    static void Main()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 5000);
        listener.Start();
        Console.WriteLine("Server started. Waiting for a client...");

        client = listener.AcceptTcpClient();
        Console.WriteLine("Client connected!");

        stream = client.GetStream();

        // Start receiving messages in a separate thread
        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Sending messages in the main thread
        while (true)
        {
            string message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) continue;

            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);

            if (message.ToLower() == "exit")
            {
                Console.WriteLine("Closing connection...");
                break;
            }
        }

        // Cleanup
        stream.Close();
        client.Close();
        listener.Stop();
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
                Console.WriteLine("\nClient: " + message);
                Console.Write("You: "); // Preserve user input formatting
            }
        }
        catch
        {
            Console.WriteLine("\nClient disconnected.");
        }
    }
}
