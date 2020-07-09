using System;
using GameApp;
using StereoFramework.GameApp.exceptions;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_Click : IComponent
    {
        private Entity parent;
        public Message message;

        public Comp_Click(Entity e, Enum ev, string m)
        {
            this.SetParentEntity(e);
            this.message = new Message(ev, m);
        }

        public Comp_Click(Entity e, Message m)
        {
            this.SetParentEntity(e);
            this.message = m;
        }

        public void OnInitialize(App app)
        {

        }

        public void OnAdded()
        {
            var c = this.parent.GetComponent<Comp_Spatial>();
            if(c == null)
            {
                throw new ComponentNotAttachedException();
            }
        }

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }
    }
}
