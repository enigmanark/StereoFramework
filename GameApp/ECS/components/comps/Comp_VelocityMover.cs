using System;
using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_VelocityMover : IComponent
    {
        private Entity parent;
        public Vector2 move_direction;
        public float velocity;

        public Comp_VelocityMover(Entity p, float v)
        {
            this.SetParentEntity(p);
            move_direction = new Vector2();
            velocity = v;
        }

        public void OnInitialize(App app)
        {

        }

        public void OnPostInitialization(App app)
        {

        }

        public void OnLoad(App app)
        {

        }

        public void OnUnload()
        {

        }

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }
    }
}
