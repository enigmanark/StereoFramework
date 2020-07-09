using System;
using System.Collections.Generic;
using System.Diagnostics;
using StereoFramework.GameApp.ECS.systems;

namespace StereoFramework.GameApp
{
    public class EventBoard
    {
        private List<IEventListener> subscribedSystems;
        private List<Event> eventQueue;

        public EventBoard()
        {
            this.subscribedSystems = new List<IEventListener>();
            this.eventQueue = new List<Event>();
        }

        public void Update()
        {
            //Move the queued events to this list
            List<Event> toProcess = new List<Event>();
            foreach(Event e in this.eventQueue)
            {
                toProcess.Add(e);
            }
            //Clear the queue
            eventQueue.Clear();

            //Process the events
            foreach (Event e in this.eventQueue)
            {
                foreach(IEventListener l in this.subscribedSystems)
                {
                    l.Notify(e);
                }
            }
        }

        public void Post(Event e)
        {
            this.eventQueue.Add(e);
            Debug.WriteLine("ENGINE: Event posted: " + e);
        }

        public void Unsubscribe(IEventListener l)
        {
            this.subscribedSystems.Remove(l);
        }

        public void Subscribe(IEventListener l)
        {
            this.subscribedSystems.Add(l);
        }
    }
}
