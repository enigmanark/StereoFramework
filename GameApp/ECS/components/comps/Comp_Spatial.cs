using System;
using GameApp;
using Microsoft.Xna.Framework;
using StereoFramework.GameApp.exceptions;

namespace StereoFramework.GameApp.ECS.components.comps
{
    public class Comp_Spatial : IComponent
    {
        private Entity parent;
        private Comp_Transform transform;
        private Comp_Bounds bounds;

        public Comp_Spatial(Entity e)
        {
            this.SetParentEntity(e);
        }

        public void OnInitialize(App app)
        {

        }

        public void OnAdded()
        {
            var c = this.parent.GetComponent<Comp_Transform>();
            if (c == null)
            {
                throw new ComponentNotAttachedException();
            }
            else
            {
                this.transform = c as Comp_Transform;
            }

            c = this.parent.GetComponent<Comp_Bounds>();
            if (c == null)
            {
                throw new ComponentNotAttachedException();
            }
            else
            {
                this.bounds = c as Comp_Bounds;
            }
        }

        public void SetParentEntity(Entity e)
        {
            this.parent = e;
        }

        public void SetPosition(float x, float y)
        {
            if (this.transform == null)
            {
                throw new AttemptToCallBeforeComponentAdded();
            }
            else
            {
                this.transform.position.X = x;
                this.transform.position.Y = y;
                this.bounds.bounds.X = (int)x;
                this.bounds.bounds.Y = (int)y;
            }
        }

        public Rectangle GetRectangle()
        {
            return this.bounds.bounds;
        }

        public Vector2 GetPosition()
        {
            return this.transform.position;
        }

        public void SetSize(int width, int height)
        {
            this.bounds.bounds.Width = width;
            this.bounds.bounds.Height = height;
        }

        public void SetWidth(int width)
        {
            this.bounds.bounds.Width = width;
        }

        public void SetHeight(int height)
        {
            this.bounds.bounds.Height = height;
        }

        public int GetWidth()
        {
            return this.bounds.bounds.Width;
        }

        public int GetHeight()
        {
            return this.bounds.bounds.Height;
        }
    }
}
