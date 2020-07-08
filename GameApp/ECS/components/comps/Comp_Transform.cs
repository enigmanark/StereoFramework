using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.components.comps
{
	public class Comp_Transform : IComponent
	{
        private Entity parent;
		public Vector2 position;

		public Comp_Transform(Entity p, float x, float y)
		{
            this.SetParentEntity(p);
			this.position = new Vector2();
			this.position.X = x;
			this.position.Y = y;
		}

		public Comp_Transform(Entity p)
		{
            this.SetParentEntity(p);
			this.position = new Vector2();
			this.position.X = 0;
			this.position.Y = 0;
		}

        public void SetPosition(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public void OnInitialize(App app)
        {

        }

        public void OnLoad(App app)
		{
			
		}

		public void OnUnload()
		{
			
		}

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }
    }
}
