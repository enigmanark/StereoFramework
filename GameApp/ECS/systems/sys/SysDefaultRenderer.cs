using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.ECS.components;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StereoFramework.GameApp.ECS.components.comps;

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
					if(c is Comp_Sprite)
					{
                        Comp_Sprite sprite = c as Comp_Sprite;
						sprite.Draw(batch);
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
