# TCP Chat Application (C#)

## Overview
This is a simple **TCP-based chat application** in C# that allows bidirectional communication between a **server** and a **client** using **TCP sockets**. The server and client run as separate console applications and support real-time messaging.

## Features
✅ Full-duplex communication (both server and client can send and receive messages)
✅ Multi-threaded (handles concurrent message sending/receiving)
✅ Graceful exit handling (`exit` command to close the connection)
✅ Stable and efficient network communication

## Technologies Used
- C#
- .NET Framework
- TCP Sockets
- Multi-threading

## How to Run
### 1. Clone the Repository
```sh
git clone https://github.com/TVVinudev/Client_Server_Chat.git
cd Client_Server_Chat
```

### 2. Compile the Server and Client
```sh
csc Server.cs
csc client.cs
```

### 3. Run the Server
Start the **server** first:
```sh
Server.exe
```

### 4. Run the Client
Start the **client** in a new terminal:
```sh
client.exe
```

### 5. Start Chatting!
- **Server and client can both send and receive messages**.
- Type `exit` to close the connection.

## Example Chat
### **Server Console**
```
Server started. Waiting for a client...
Client connected!
You: Hello client!
Client: Hi server!
You: How are you?
Client: I'm good, thanks!
```

### **Client Console**
```
Connected to the server. Type messages and press Enter to send.
You: Hi server!
Server: Hello client!
You: I'm good, thanks!
Server: How are you?
```

## Code Structure
```
Client_Server_Chat/
│── TCPChatApp
    │── TCPChatApp
        │── Server.cs   # Server-side application
        │── client.cs   # Client-side application
    │── TCPChatApp.sln
│── README.md      # Project documentation
```

## Enhancements (Future Work)
- [ ] Support for multiple clients
- [ ] Message encryption for secure communication
- [ ] File transfer feature

## License
This project is licensed under the MIT License. Feel free to use and modify it.

## Contributing
Feel free to submit issues or pull requests. Any contributions are welcome! 😊
