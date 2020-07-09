using System;
using System.Collections.Generic;
using System.Diagnostics;
using StereoFramework.GameApp.ECS.systems;

namespace StereoFramework.GameApp
{
    public class EventBoard
    {
        private List<IMessageListener> subscribedSystems;
        private List<Message> eventQueue;

        public EventBoard()
        {
            this.subscribedSystems = new List<IMessageListener>();
            this.eventQueue = new List<Message>();
        }

        public void Update()
        {
            //Move the queued events to this list
            List<Message> toProcess = new List<Message>();
            foreach(Message m in this.eventQueue)
            {
                toProcess.Add(m);
            }
            //Clear the queue
            eventQueue.Clear();

            //Process the events
            foreach (Message m in this.eventQueue)
            {
                foreach(IMessageListener l in this.subscribedSystems)
                {
                    l.Notify(m);
                }
            }
        }

        public void Post(Message m)
        {
            this.eventQueue.Add(m);
            Debug.WriteLine("ENGINE: Event posted: " + m);
        }

        public void Unsubscribe(IMessageListener l)
        {
            this.subscribedSystems.Remove(l);
        }

        public void Subscribe(IMessageListener l)
        {
            this.subscribedSystems.Add(l);
        }
    }
}
