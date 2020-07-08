using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.systems;
using System.Collections.Generic;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS
{
	public class Scene
    {
        private App app;
        private List<Entity> entities;
		private List<ISystem> sceneComponents;
		private List<ISystem_Renderer> sceneRenderComps;
        private SimpleCamera2D camera;

        public Scene(App app)
		{
            this.app = app;
			this.entities = new List<Entity>();
			this.sceneComponents = new List<ISystem>();
            this.sceneRenderComps = new List<ISystem_Renderer>();
            this.camera = new SimpleCamera2D();
        }

        public SimpleCamera2D GetCamera()
        {
            return this.camera;
        }

        public List<Entity> GetEntities()
        {
            return this.entities;
        }

        public List<Entity> GetAllEntitiesWithTag(string tag)
        {
            var list = new List<Entity>();
            foreach(Entity e in this.entities)
            {
                if(e.HasTag(tag))
                {
                    list.Add(e);
                }
            }

            return list;
        }

        public Entity GetFirstEntityWithTag(string tag)
        {
            foreach(Entity e in this.entities)
            {
                if(e.HasTag(tag))
                {
                    return e;
                }
            }

            return null;
        }

        public void AddSceneComponentRenderer(ISystem_Renderer renderer)
		{
			this.sceneRenderComps.Add(renderer);
		}

		public void AddSceneComponent(ISystem c)
		{
			this.sceneComponents.Add(c);
		}

		public void AddEntity(Entity e)
		{
			this.entities.Add(e);
		}

        public void OnInitialize(App app)
        {
            Debug.WriteLine("ENGINE: Initializing scene...");

            Debug.WriteLine("ENGINE: Initializing entities...");
            foreach(Entity e in this.entities)
            {
                e.Initialize(app);
            }
            Debug.WriteLine("ENGINE: Entities initialized.");
            Debug.WriteLine("ENGINE: Initializing scene components...");
            foreach(ISystem s in this.sceneComponents)
            {
                s.Initialize(app);
            }
            Debug.WriteLine("ENGINE: Scene Components initialized.");
            Debug.WriteLine("ENGINE: Initializing camera...");
            this.camera.Initialize(app.GraphicsDevice.Viewport);
            Debug.WriteLine("ENGINE: Camera initalized.");
            Debug.WriteLine("ENGINE: Scene has been initialized.");
        }

        public void OnLoad(App app)
		{
            Debug.WriteLine("ENGINE: Loading scene...");
			foreach(Entity e in this.entities)
			{
				e.Load(app);
			}
            Debug.WriteLine("ENGINE: Scene has been loaded.");
		}

		public void OnUnload()
		{
            Debug.WriteLine("ENGINE: Unloading scene...");
            foreach (Entity e in this.entities)
			{
				e.Unload();
			}
            Debug.WriteLine("ENGINE: Scene has been unloaded.");
        }

		public void Update(GameTime gameTime)
        {
			foreach(ISystem s in this.sceneComponents)
			{
                if (s is ISystem_Handler)
                {
                    ISystem_Handler h = s as ISystem_Handler;
                    h.Process(this.sceneComponents, gameTime);
                }
                else
                {
                    s.Process(this.entities, gameTime);
                }
			}

            this.camera.UpdateCamera(this.app.GraphicsDevice.Viewport);
        }

		public void Draw(GraphicsDevice graphics, SpriteBatch spritebatch)
		{
            spritebatch.Begin(transformMatrix: this.camera.GetTransformMatrix());	
			foreach (ISystem_Renderer c in this.sceneRenderComps)
			{
				c.Draw(graphics, spritebatch, this.entities);
			}
			spritebatch.End();
		}
	}
}
