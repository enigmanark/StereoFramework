using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.comps_e;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StereoFramework.GameApp.ECS.comps_scene.comps
{
	public class SceneCompSpriteRenderer : ISceneComponentRenderer
	{
		public void Draw(SpriteBatch batch, List<Entity> entities)
		{
			foreach(Entity e in entities)
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
