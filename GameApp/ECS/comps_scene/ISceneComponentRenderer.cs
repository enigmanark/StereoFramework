using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS.comps_scene
{
	public interface ISceneComponentRenderer
	{
		void Draw(SpriteBatch batch, List<Entity> entities);
	}
}
