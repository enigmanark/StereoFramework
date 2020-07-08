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
        private List<Entity> entityQueue;
        private List<ISystem> sysQueue;
        private List<Entity> entities;
        private List<ISystem> systems;
		private List<ISystem_Renderer> renderers;
        private SimpleCamera2D camera;

        public Scene(App app)
		{
            this.app = app;
			this.entities = new List<Entity>();
			this.systems = new List<ISystem>();
            this.renderers = new List<ISystem_Renderer>();
            this.camera = new SimpleCamera2D();
            this.entityQueue = new List<Entity>();
            this.sysQueue = new List<ISystem>();
        }

        public SimpleCamera2D GetCamera()
        {
            return this.camera;
        }

        public List<Entity> GetEntities()
        {
            return this.entities;
        }

        public Entity GetEntityWithId(string id)
        {
            foreach(Entity e in this.entities)
            {
                if(e.GetId().Equals(id))
                {
                    return e;
                }
            }

            return null;
        }

        public void KillEntityWithId(string id)
        {
            var entity = this.GetEntityWithId(id);
            entity.Kill();
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

        private void RemoveDeadEntities()
        {
            List<Entity> newList = new List<Entity>();
            foreach(Entity e in this.entities)
            {
                if (!e.IsDying())
                {
                    newList.Add(e);
                }
            }

            this.entities = newList;
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

        public void AddRenderer(ISystem_Renderer renderer)
		{
			this.renderers.Add(renderer);
		}

		public void AddSystem(ISystem s)
		{
            this.sysQueue.Add(s);
		}

		public void AddEntity(Entity e)
		{
            this.entityQueue.Add(e);
		}


        private void ProcessEntityQueue()
        {
            foreach(Entity e in this.entityQueue)
            {
                e.Initialize(this.app);
                this.entities.Add(e);
            }

            foreach(Entity e in this.entityQueue)
            {
                e.PostInitialize(this.app);
                e.Load(this.app);
                Debug.WriteLine("ENGINE: Initialized and loaded an entity.");
            }
            this.entityQueue.Clear();
        }

        private void ProcessSystemQueue()
        {
            foreach(ISystem s in this.sysQueue)
            {
                s.Initialize(this.app);
                this.systems.Add(s);
            }

            foreach(ISystem s in this.sysQueue)
            {
                s.PostInitialization(this.app);
                Debug.WriteLine("ENGINE: Initialized a system.");
            }

            this.sysQueue.Clear();
        }

        public void OnInitialize(App app)
        {
            Debug.WriteLine("ENGINE: Initializing camera...");
            this.camera.Initialize(app.GraphicsDevice.Viewport);
            Debug.WriteLine("ENGINE: Camera initalized.");
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
            this.ProcessEntityQueue();
            this.ProcessSystemQueue();
            foreach (ISystem s in this.systems)
			{
                if (s is ISystem_Handler)
                {
                    ISystem_Handler h = s as ISystem_Handler;
                    h.Process(this.systems, gameTime);
                }
                else
                {
                    s.Process(this.entities, gameTime);
                }
			}

            this.RemoveDeadEntities();

            this.camera.UpdateCamera(this.app.GraphicsDevice.Viewport);
        }

		public void Draw(GraphicsDevice graphics, SpriteBatch spritebatch)
		{
            spritebatch.Begin(transformMatrix: this.camera.GetTransformMatrix());	
			foreach (ISystem_Renderer c in this.renderers)
			{
				c.Draw(graphics, spritebatch, this.entities);
			}
			spritebatch.End();
		}
	}
}
