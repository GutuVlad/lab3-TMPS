using System;
using System.Collections.Generic;
 
namespace Mediator
{
    // Mediator interface
    public interface IChatMediator
    {
        void AddUser(IUser user);
        void SendMessage(string message, IUser sender);
    }
    // COncrete Mediator
    public class ChatMediator : IChatMediator
    {
        List<IUser> users;

        public ChatMediator()
        {
            users = new List<IUser>();
        }

        public void AddUser(IUser user)
        {
            users.Add(user);
        }

        public void SendMessage(string message, IUser sender)
        {
            foreach (IUser user in users)
            {
                // Sender will not receive the message
                if (user != sender)
                    user.ReceiveMessage(message);
            }
        }
    }
    // Colleague interface
    public interface IUser
    {
        void SendMessage(string message);
        void ReceiveMessage(string message);
    }
    // Concrete Colleague 1
    public class BasicUser : IUser
    {
        string name;
        IChatMediator chatMediator;

        public BasicUser(IChatMediator chatMediator, string name)
        {
            this.name = name;
            this.chatMediator = chatMediator;
        }

        public void SendMessage(string message)
        {
            chatMediator.SendMessage(message, this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine("User Type: Basic -- " + name + "; received message: " + message);
        }
    }
    // Concrete Colleague 2
    public class PremiumUser : IUser
    {
        string name;
        IChatMediator chatMediator;

        public PremiumUser(IChatMediator chatMediator, string name)
        {
            this.name = name;
            this.chatMediator = chatMediator;
        }

        public void SendMessage(string message)
        {
            chatMediator.SendMessage(message, this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine("User Type: Preminum -- " + name + "; received message: " + message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IChatMediator chatMediator = new ChatMediator();
            // create users and add them to chat mediator's user list
            IUser john = new BasicUser(chatMediator, "John");
            IUser tina = new PremiumUser(chatMediator, "Tina");
            IUser lara = new PremiumUser(chatMediator, "Lara");
            chatMediator.AddUser(john);
            chatMediator.AddUser(tina);
            chatMediator.AddUser(lara);
            // send message
            lara.SendMessage("Hello Everyone!");
            Console.ReadLine();
        }
    }
}