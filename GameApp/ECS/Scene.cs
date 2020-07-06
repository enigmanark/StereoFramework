using GameApp;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.comps_scene;
using System.Collections.Generic;
using System.Security.Policy;

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

		public void OnLoad(App app)
		{
			foreach(Entity e in this.entities)
			{
				e.Load(app);
			}
		}

		public void OnUnload()
		{
			foreach(Entity e in this.entities)
			{
				e.Unload();
			}
		}

		public void Update()
		{
			foreach(ISceneComponent c in this.sceneComponents)
			{
				c.process(this.entities);
			}
		}

		public void Draw(SpriteBatch spritebatch)
		{
			
			foreach (ISceneComponentRenderer c in this.sceneRenderComps)
			{
				c.Draw(spritebatch, this.entities);
			}
		}
	}
}
