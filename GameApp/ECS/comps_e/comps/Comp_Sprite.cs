using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS.comps_e.comps
{
	public class Comp_Sprite : IComponent, IDrawable
	{
		private Entity parent;
		private String texture_path;
		private Texture2D texture; 

		public Comp_Sprite(Entity p, String path)
		{
			this.parent = p;
			this.texture_path = path;
		}

		public void Draw(SpriteBatch batch)
		{
			Comp_Transform transform = this.parent.GetComponent<Comp_Transform>() as Comp_Transform;
			batch.Draw(this.texture, transform.position, Color.White);
		}

		public void OnLoad(App app)
		{
			if (this.parent.HasComponent<Comp_Transform>())
			{
				this.texture = app.Content.Load<Texture2D>(this.texture_path);
				Debug.WriteLine("ENGINE: Loaded texture " + this.texture_path + ".");
			}
			else
			{
				Debug.WriteLine("ENGINE ERROR: Entity does not have a transform with sprite " + this.texture_path + ".");
				Debug.WriteLine("ENGINE: Closing...");
				Environment.Exit(1);
			}
		}

		public void OnUnload()
		{
			this.texture.Dispose();
			Debug.WriteLine("ENGINE: Disposed of texture " + this.texture_path + ".");
		}
	}
}
