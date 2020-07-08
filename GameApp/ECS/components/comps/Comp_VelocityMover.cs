using System;
using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_VelocityMover : IComponent
    {
        public Vector2 move_direction;
        public float velocity;

        public Comp_VelocityMover(float v)
        {
            move_direction = new Vector2();
            velocity = v;
        }

        public void OnInitialize(App app)
        {

        }

        public void OnLoad(App app)
        {

        }

        public void OnUnload()
        {

        }
    }
}
