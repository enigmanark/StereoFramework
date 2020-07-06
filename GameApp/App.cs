using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS;
using System.Diagnostics;

namespace GameApp
{
    public class App : Game
    {
        bool ranUpdateOnce = false;
        bool ranDrawOnce = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Scene currentScene;

        public App()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected void SetStartScene(Scene scene)
		{
            Debug.WriteLine("ENGINE: Start scene set.");
            this.currentScene = scene;
		}

        protected override void Initialize()
        {
            Debug.WriteLine("ENGINE: Initializing.");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("ENGINE: Loading content.");
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            this.currentScene.OnLoad();
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

            this.currentScene.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            if (!this.ranDrawOnce)
            {
                Debug.WriteLine("ENGINE: Starting main draw loop.");
                this.ranDrawOnce = true;
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.currentScene.Draw(this.spriteBatch);

            base.Draw(gameTime);
        }
    }
}
