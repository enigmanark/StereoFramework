using System;
namespace StereoFramework.GameApp
{
    public class Message
    {
        public string message;
        public Enum theEvent;

        public Message(Enum ev, string message)
        {
            this.theEvent = ev;
            this.message = message;
        }
    }
}
