using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.components;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using IDrawable = StereoFramework.GameApp.ECS.components.IDrawable;

namespace StereoFramework.GameApp.ECS.systems.sys
{
	public class SystemDefaultRenderer : ISystem_Renderer
	{
        private Color clearColor;

        public SystemDefaultRenderer()
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
