using System;

public interface IChatApp
{
    void SendMessage(string message);
    void ReceiveMessage();
}

public abstract class ChatApp : IChatApp
{
    public readonly string appName;

    public ChatApp(string appName)
    {
        this.appName = appName;
    }

    public abstract void SendMessage(string message);
    public abstract void ReceiveMessage();
}

public class WhatsApp : ChatApp
{
    public WhatsApp() : base("WhatsApp") { }

    public override void SendMessage(string message)
    {
        Console.WriteLine($"Sending message through {appName}: {message}");
    }

    public override void ReceiveMessage()
    {
        Console.WriteLine($"Receiving message through {appName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IChatApp whatsApp = new WhatsApp();
        whatsApp.SendMessage("Hello, World!");
        whatsApp.ReceiveMessage();
    }
}