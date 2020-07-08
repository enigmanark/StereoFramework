using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameApp;
using Microsoft.Xna.Framework;
using StereoFramework.GameApp.ECS.components.comps;

namespace StereoFramework.GameApp.ECS.systems.sys
{
    public class SystemVelocityMover : ISystem
    {
        public SystemVelocityMover()
        {

        }

        public void Initialize(App app)
        {

        }

        public void PostInitialization(App app)
        {

        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                if(e.HasComponent<Comp_VelocityMover>())
                {
                    var c = e.GetComponent<Comp_VelocityMover>();
                    var m = c as Comp_VelocityMover;

                    c = e.GetComponent<Comp_Transform>();
                    var t = c as Comp_Transform;

                    var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

                    t.position.X = t.position.X + m.move_direction.X * m.velocity * delta;
                    t.position.Y = t.position.Y + m.move_direction.Y * m.velocity * delta;
                }
            }
        }
    }
}
