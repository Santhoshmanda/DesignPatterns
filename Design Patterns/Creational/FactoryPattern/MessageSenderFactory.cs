using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    // Product interface
    interface IMessageSender
    {
        void SendMessage(string recipient, string message);
    }

    // Concrete products
    class EmailSender : IMessageSender
    {
        public void SendMessage(string recipient, string message)
        {
            // Send message via email
        }
    }

    class SMSSender : IMessageSender
    {
        public void SendMessage(string recipient, string message)
        {
            // Send message via SMS
        }
    }

    class PushNotificationSender : IMessageSender
    {
        public void SendMessage(string recipient, string message)
        {
            // Send message via push notification
        }
    }

    // Factory interface
    interface IMessageSenderFactory
    {
        IMessageSender CreateMessageSender(MessageChannel channel);
    }

    // Concrete factory
    class MessageSenderFactory : IMessageSenderFactory
    {
        public IMessageSender CreateMessageSender(MessageChannel channel)
        {
            switch (channel)
            {
                case MessageChannel.Email:
                    return new EmailSender();
                case MessageChannel.SMS:
                    return new SMSSender();
                case MessageChannel.PushNotification:
                    return new PushNotificationSender();
                default:
                    throw new NotSupportedException($"Message channel '{channel}' is not supported.");
            }
        }
    }

    enum MessageChannel
    {
        Email,
        SMS,
        PushNotification
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IMessageSenderFactory messageSenderFactory = new MessageSenderFactory();

    //        IMessageSender emailSender = messageSenderFactory.CreateMessageSender(MessageChannel.Email);
    //        emailSender.SendMessage("recipient@example.com", "Hello, this is an email message.");

    //        IMessageSender pushNotificationSender = messageSenderFactory.CreateMessageSender(MessageChannel.PushNotification);
    //        pushNotificationSender.SendMessage("device_token", "Hello, this is a push notification message.");
    //    }
    //}

}

