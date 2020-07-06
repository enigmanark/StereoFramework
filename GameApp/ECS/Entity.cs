using GameApp;
using ProjectRetrosic.GameApp.ECS.comps_e;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRetrosic.GameApp.ECS
{
	public class Entity
	{
		private List<IComponent> components; 

		public Entity()
		{
			
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
