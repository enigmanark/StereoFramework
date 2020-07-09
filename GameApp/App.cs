using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp;
using StereoFramework.GameApp.ECS;
using System.Diagnostics;

namespace GameApp
{
    public class App : Game, IEventListener
    {
        private string title;
        private int windowWidth;
        private int windowHeight;
        bool ranUpdateOnce = false;
        bool ranDrawOnce = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Scene currentScene;
        private EventBoard eventBoard;
        private InputHandler inputHandler;

        public App(int width, int height, string title)
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.title = title;
            this.windowWidth = width;
            this.windowHeight = height;
            this.eventBoard = new EventBoard();
            this.inputHandler = new InputHandler();
        }

        public App()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "A Stereo Framework Game";
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = 1366;
            this.graphics.PreferredBackBufferHeight = 768;
            this.graphics.ApplyChanges();
            this.eventBoard = new EventBoard();
            this.inputHandler = new InputHandler();
        }

        public void ChangeScene(Scene sc)
        {
            this.eventBoard.Post(Event.ChangingScene);
            this.currentScene.OnUnload();
            this.currentScene = sc;
            this.currentScene.OnInitialize(this);
            this.eventBoard.Post(Event.SceneChangeComplete);
        }

        protected void SetStartScene(Scene scene)
		{
            this.currentScene = scene;
            this.eventBoard.Post(Event.StartSceneSet);
        }

        protected override void Initialize()
        {
            this.eventBoard.Post(Event.Initializing);
            Window.Title = this.title;
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = this.windowWidth;
            this.graphics.PreferredBackBufferHeight = this.windowHeight;
            this.graphics.ApplyChanges();
            this.currentScene.OnInitialize(this);
            base.Initialize();
            this.eventBoard.Post(Event.InitializingComplete);
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void UnloadContent()
        {
            this.eventBoard.Post(Event.UnloadingContent);
            this.currentScene.OnUnload();
            this.eventBoard.Post(Event.UnloadingContentComplete);

        }


        protected override void Update(GameTime gameTime)
        {
            if(!this.ranUpdateOnce)
			{
                this.eventBoard.Post(Event.StartingUpdateLoop);
                this.ranUpdateOnce = true;
			}
            this.inputHandler.Process(gameTime);
            this.currentScene.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            if (!this.ranDrawOnce)
            {
                this.eventBoard.Post(Event.StartingDrawLoop);
                this.ranDrawOnce = true;
            }

            this.currentScene.Draw(this.graphics.GraphicsDevice, this.spriteBatch);

            base.Draw(gameTime);
        }

        public InputHandler GetInputHandler()
        {
            return this.inputHandler;
        }

        public EventBoard GetEventBoard()
        {
            return this.eventBoard;
        }

        public void Notify(Event e)
        {
            if(e == Event.Quit)
            {
                this.Exit();
            }
        }
    }
}
