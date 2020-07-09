using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StereoFramework.GameApp.exceptions;
using System;
using System.Diagnostics;

namespace StereoFramework.GameApp.ECS.components.comps
{
	public class Comp_Sprite : IComponent, IHasContent
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

        }

        public void OnAdded()
        {
            this.transform = this.parent.GetComponent<Comp_Transform>() as Comp_Transform;
            if (this.transform == null)
            {
                throw new ComponentNotAttachedException();
            }
        }

        public void OnLoad(App app)
		{
            this.texture = app.Content.Load<Texture2D>(this.texture_path);
            Debug.WriteLine("ENGINE: Loaded texture " + this.texture_path + ".");
            var c = this.parent.GetComponent<Comp_Bounds>();
            if(c != null)
            {
                var bounds = c as Comp_Bounds;
                bounds.bounds.Width = this.GetWidth();
                bounds.bounds.Height = this.GetHeight();
                Debug.WriteLine("ENGINE: Sprite found bounds on entity, setting bounds to size of texture.");
            }
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

        public int GetWidth()
        {
            return this.texture.Width;
        }

        public int GetHeight()
        {
            return this.texture.Height;
        }
    }
}
