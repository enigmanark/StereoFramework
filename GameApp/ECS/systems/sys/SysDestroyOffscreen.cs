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
        private Rectangle cameraView;
        private Scene scene;

        public SystemDestroyOffScreen()
        {
        }

        public void Initialize(App app)
        {
            this.scene = app.currentScene;
            this.cameraView = app.currentScene.GetCamera().GetVisibleArea();
        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {
            foreach(Entity e in entities)
            {
                if (e.HasComponent<Comp_DestroyOffscreen>())
                {
                    Comp_Transform t = e.GetComponent<Comp_Transform>() as Comp_Transform;
                    if(!this.cameraView.Contains(t.position))
                    {
                        this.scene.KillEntityWithId(e.GetId());
                        Debug.WriteLine("ENGINE: Killed entity offscreen with id " + e.GetId());
                    }
                }
            }
        }
    }
}
