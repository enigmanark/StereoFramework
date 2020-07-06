using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRetrosic.GameApp.ECS.comps_e.comps
{
	class Comp_Transform : IComponent
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

		public void OnLoad()
		{
			
		}

		public void OnUnload()
		{
			
		}
	}
}
