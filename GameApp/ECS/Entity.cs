using GameApp;
using StereoFramework.GameApp.ECS.comps_e;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS
{
	public class Entity
	{
		private List<IComponent> components;
        private List<string> tags;

		public Entity()
		{
			this.components = new List<IComponent>();
		}

        public void AddTag(string tag)
        {
            this.tags.Add(tag);
        }

        public List<string> GetTags()
        {
            return this.tags;
        }

        public bool HasTag(string tag)
        {
            foreach(string t in this.tags)
            {
                if(t.Equals(tag))
                {
                    return true;
                }
            }

            return false;
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
