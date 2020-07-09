using System;
using GameApp;
using StereoFramework.GameApp.ECS;

namespace StereoFramework.GameApp
{
    public class SceneHandler : IEventListener
    {
        private App app;
        private Scene currentScene;

        public SceneHandler(App app)
        {
            this.app = app;
        }

        public void ChangeScene(Scene sc)
        {
            this.currentScene.OnUnload();
            this.currentScene = sc;
            this.currentScene.OnInitialize(this.app);
        }

        public void SetStartScene(Scene sc)
        {
            this.currentScene = sc;
        }

        public Scene GetCurrentScene()
        {
            return this.currentScene;
        }

        public void Notify(Event e)
        {
            if(e == )
        }
    }
}
