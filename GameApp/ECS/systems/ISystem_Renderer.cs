using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS.systems
{
	public interface ISystem_Renderer
	{
		void Draw(GraphicsDevice graphics, SpriteBatch batch, List<Entity> entities);
	}
}
