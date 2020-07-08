using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameApp;
using Microsoft.Xna.Framework;
using StereoFramework.GameApp.ECS.components.comps;

namespace StereoFramework.GameApp.ECS.systems.sys
{
    public class SystemDestroyOffScreen : ISystem
    {
        private SimpleCamera2D camera;
        private Scene scene;

        public SystemDestroyOffScreen()
        {
        }

        public void Initialize(App app)
        {

        }

        public void PostInitialization(App app)
        {
            this.scene = app.currentScene;
            this.camera = app.currentScene.GetCamera();
        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                if (e.HasComponent<Comp_DestroyOffscreen>())
                {
                    Comp_Transform t = e.GetComponent<Comp_Transform>() as Comp_Transform;
                    if(this.camera.GetVisibleArea().Width == 0 && this.camera.GetVisibleArea().Height == 0)
                    {
                        Debug.WriteLine("ENGINE WARNING: Camera visible area rect reporting 0 width and height.");
                    }
                    else if (!this.camera.GetVisibleArea().Contains(t.position))
                    {
                        this.scene.KillEntityWithId(e.GetId());
                        Debug.WriteLine("ENGINE: Killed entity offscreen with id " + e.GetId());
                        Debug.WriteLine("ENGINE: Bounds are " + this.camera.GetVisibleArea());
                    }
                }
            }
        }
    }
}
