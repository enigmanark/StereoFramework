using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS;
using System.Diagnostics;

namespace GameApp
{
    public class App : Game
    {
        private string title;
        private int windowWidth;
        private int windowHeight;
        bool ranUpdateOnce = false;
        bool ranDrawOnce = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Scene currentScene;

        public App(int width, int height, string title)
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.title = title;
            this.windowWidth = width;
            this.windowHeight = height;
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
        }

        public void ChangeScene(Scene sc)
        {
            Debug.WriteLine("ENGINE: Changing scene...");
            this.currentScene.OnUnload();
            this.currentScene = sc;
            this.currentScene.OnLoad(this);
            this.currentScene.OnInitialize(this);
            Debug.WriteLine("ENGINE: Scene changed.");
        }

        protected void SetStartScene(Scene scene)
		{
            Debug.WriteLine("ENGINE: Start scene set.");
            this.currentScene = scene;
		}

        protected override void Initialize()
        {
            Debug.WriteLine("ENGINE: Initializing.");
            Window.Title = this.title;
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = this.windowWidth;
            this.graphics.PreferredBackBufferHeight = this.windowHeight;
            this.graphics.ApplyChanges();
            this.currentScene.OnInitialize(this);
            Debug.WriteLine("ENGINE: Initialization done.");
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Debug.WriteLine("ENGINE: Loading content.");
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.currentScene.OnLoad(this);
            Debug.WriteLine("ENGINE: Content loaded.");
        }


        protected override void UnloadContent()
        {
            Debug.WriteLine("ENGINE: Unloading content.");
            this.currentScene.OnUnload();
            Debug.WriteLine("ENGINE: Quitting...");
        }


        protected override void Update(GameTime gameTime)
        {
            if(!this.ranUpdateOnce)
			{
                Debug.WriteLine("ENGINE: Starting main update loop.");
                this.ranUpdateOnce = true;
			}

            this.currentScene.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            if (!this.ranDrawOnce)
            {
                Debug.WriteLine("ENGINE: Starting main draw loop.");
                this.ranDrawOnce = true;
            }

            this.currentScene.Draw(this.graphics.GraphicsDevice, this.spriteBatch);

            base.Draw(gameTime);
        }
    }
}
