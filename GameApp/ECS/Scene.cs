using GameApp;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.comps_scene;
using System.Collections.Generic;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS
{
	public class Scene
	{
		private List<Entity> entities;
		private List<ISceneComponent> sceneComponents;
		private List<ISceneComponentRenderer> sceneRenderComps;
		public Scene()
		{
			this.entities = new List<Entity>();
			this.sceneComponents = new List<ISceneComponent>();
			this.sceneRenderComps = new List<ISceneComponentRenderer>();
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

        public void AddSceneComponentRenderer(ISceneComponentRenderer renderer)
		{
			this.sceneRenderComps.Add(renderer);
		}

		public void AddSceneComponent(ISceneComponent c)
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
            foreach(Entity e in this.entities)
            {
                e.Initialize(app);
            }
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

		public void Update()
        {
			foreach(ISceneComponent c in this.sceneComponents)
			{
                if (c is ISceneComponentHandler)
                {
                    ISceneComponentHandler h = c as ISceneComponentHandler;
                    h.Process(this.sceneComponents);
                }
                else
                {
                    c.Process(this.entities);
                }
			}
		}

		public void Draw(GraphicsDevice graphics, SpriteBatch spritebatch)
		{
			spritebatch.Begin();	
			foreach (ISceneComponentRenderer c in this.sceneRenderComps)
			{
				c.Draw(graphics, spritebatch, this.entities);
			}
			spritebatch.End();
		}
	}
}
