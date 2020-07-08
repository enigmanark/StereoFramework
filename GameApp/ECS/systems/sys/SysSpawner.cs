using System;
using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;
using StereoFramework.GameApp.ECS.components;

namespace StereoFramework.GameApp.ECS.systems.sys
{
    public class SystemSpawner : ISystem
    {
        private App app;

        public SystemSpawner()
        {
        }

        public void Initialize(App app)
        {
            this.app = app;
        }

        public void PostInitialization(App app)
        {

        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                List<IComponent> comps = e.GetComponents();
                foreach(IComponent c in comps)
                {
                    if (c is ISpawnable)
                    {
                        ISpawnable s = c as ISpawnable;
                        if(s.IsSpawning())
                        {
                            s.SetSpawning(false);
                            var spawned = s.GetSpawningEntity();
                            app.currentScene.AddEntity(spawned);
                        }
                    }
                }
            }
        }
    }
}
