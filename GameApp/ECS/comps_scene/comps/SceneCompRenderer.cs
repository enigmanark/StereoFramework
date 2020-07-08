using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.comps_e;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using IDrawable = StereoFramework.GameApp.ECS.comps_e.IDrawable;

namespace StereoFramework.GameApp.ECS.comps_scene.comps
{
	public class SceneComponentRenderer : ISceneComponentRenderer
	{
        private Color clearColor;

        public SceneComponentRenderer()
        {
            clearColor = Color.Black;
        }

        public void Draw(GraphicsDevice graphics, SpriteBatch batch, List<Entity> entities)
		{
            graphics.Clear(this.clearColor);
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

        public void SetDefaultClearColor(Color c)
        {
            this.clearColor = c;
        }
    }
}
