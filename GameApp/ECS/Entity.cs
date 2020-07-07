using GameApp;
using StereoFramework.GameApp.ECS.comps_e;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS
{
	public class Entity
	{
		private List<IComponent> components; 

		public Entity()
		{
			this.components = new List<IComponent>();
		}

		public List<IComponent> GetComponents()
		{
			return this.components;
		}

		public IComponent GetComponent<T>()
		{
			foreach(IComponent c in this.components)
			{
				if(c is T)
				{
					return c;
				}
			}
			return null;
		}

		public bool HasComponent<T>()
		{
			foreach(IComponent c in this.components)
			{
				if(c is T)
				{
					return true;
				}
			}

			return false;
		}

		public void AddComponent(IComponent c)
		{
			this.components.Add(c);
		}

        public void Initialize(App app)
        {
            foreach(IComponent c in this.components)
            {
                c.OnInitialize(app);
            }
        }

        public void Load(App app)
		{
			foreach(IComponent c in this.components)
			{
				c.OnLoad(app);
			}
		}

		public void Unload()
		{
			foreach(IComponent c in this.components)
			{
				c.OnUnload();
			}
		}

	}
}
