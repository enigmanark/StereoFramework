using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.comps_e;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using IDrawable = StereoFramework.GameApp.ECS.comps_e.IDrawable;

namespace StereoFramework.GameApp.ECS.comps_scene.comps
{
	public class SceneCompSpriteRenderer : ISceneComponentRenderer
	{
		public void Draw(GraphicsDevice graphics, SpriteBatch batch, List<Entity> entities)
		{
            graphics.Clear(Color.Bisque);
            foreach (Entity e in entities)
			{
				foreach(IComponent c in e.GetComponents())
				{
					if(c is IDrawable)
					{
                        IDrawable drawable = c as IDrawable;
						drawable.Draw(batch);
					}
				}
			}
		}
	}
}
