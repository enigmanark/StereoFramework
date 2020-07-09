using System;
using GameApp;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_Click : IComponent
    {
        private Entity parent;
        public Event theEvent;

        public Comp_Click(Entity e, Event ev)
        {
            this.SetParentEntity(e);
            this.theEvent = ev;
        }

        public void OnInitialize(App app)
        {

        }

        public void OnAdded()
        {

        }

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }
    }
}
