using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.comps_e.comps
{
	public class Comp_Transform : IComponent
	{
		public Vector2 position;

		public Comp_Transform(float x, float y)
		{
			this.position = new Vector2();
			this.position.X = x;
			this.position.Y = y;
		}

		public Comp_Transform()
		{
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
	}
}
