using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRetrosic.GameApp.ECS.comps_scene
{
	interface ISceneComponentRenderer
	{
		void Draw(SpriteBatch batch, List<Entity> entities);
	}
}
