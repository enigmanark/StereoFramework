using System;
using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_Bounds : IComponent
    {
        private Entity parent;
        public Rectangle bounds;

        public Comp_Bounds(Entity e, Rectangle rect)
        {
            this.bounds = rect;
        }

        public Comp_Bounds(Entity e)
        {
            this.bounds = new Rectangle();
            this.bounds.X = 0;
            this.bounds.Y = 0;
            this.bounds.Width = 32;
            this.bounds.Height = 32;
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
