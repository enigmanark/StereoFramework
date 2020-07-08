using GameApp;
using StereoFramework.GameApp.ECS.components;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS
{
	public class Entity
	{
        private bool dying = false;
        private string id;
		private List<IComponent> components;
        private List<string> tags;

		public Entity()
		{
            this.tags = new List<string>();
			this.components = new List<IComponent>();
		}

        public void Kill()
        {
            this.dying = true;
        }

        public bool IsDying()
        {
            return this.dying;
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

        public string GetId()
        {
            return this.id;
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
            this.id = this.GenerateUniqueId();
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

        private string GenerateUniqueId()
        {
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                                "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

            Random rand = new Random();
            string d = "";
            for(var i = 0; i < 25; i++)
            {
                string k;
                var choose = rand.Next(0, 1+1);
                if(choose == 0)
                {
                    k = numbers[rand.Next(0, 9+1)];
                }
                else
                {
                    k = letters[rand.Next(0, 25+1)];
                }
                d = d + k;
            }

            return d;
        }

    }
}
