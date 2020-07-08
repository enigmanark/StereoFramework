using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS.components.comps
{
	public class Comp_Sprite : IComponent
	{
		private Entity parent;
        private Comp_Transform transform;
		private String texture_path;
		private Texture2D texture; 

		public Comp_Sprite(Entity p, String path)
		{
            this.SetParentEntity(p);
            this.texture_path = path;
		}

		public void Draw(SpriteBatch batch)
		{
			batch.Draw(this.texture, transform.position, Color.White);
		}

        public void OnInitialize(App app)
        {
            this.transform = this.parent.GetComponent<Comp_Transform>() as Comp_Transform;
            if (this.transform == null)
            {
                Debug.WriteLine("ENGINE ERROR: Entity does not have a transform with sprite " + this.texture_path + ".");
                Debug.WriteLine("ENGINE: Closing...");
                Environment.Exit(1);
            }
        }

        public void OnLoad(App app)
		{
            this.texture = app.Content.Load<Texture2D>(this.texture_path);
            Debug.WriteLine("ENGINE: Loaded texture " + this.texture_path + ".");
		}

		public void OnUnload()
		{
			this.texture.Dispose();
			Debug.WriteLine("ENGINE: Disposed of texture " + this.texture_path + ".");
		}

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }
    }
}
