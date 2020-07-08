using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StereoFramework.GameApp
{
    public class SimpleCamera2D
    {
        public float zoom;
        public Vector2 position;
        private Rectangle bounds;
        private Rectangle visibleArea;
        private Matrix transform;

        public SimpleCamera2D()
        {
            this.zoom = 1;
            this.position = Vector2.Zero;
        }

        public void Initialize(Viewport viewport)
        {
            this.bounds = viewport.Bounds;
        }


        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(this.transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(this.bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, this.bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(this.bounds.Width, this.bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            visibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        private void UpdateMatrix()
        {
            this.transform = Matrix.CreateTranslation(new Vector3(-this.position.X, -this.position.Y, 0)) *
                    Matrix.CreateScale(this.zoom) *
                    Matrix.CreateTranslation(new Vector3(this.bounds.Width * 0.5f, this.bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }

        public void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = this.position + movePosition;
            this.position = newPosition;
        }

        public void UpdateCamera(Viewport viewport)
        {
            this.bounds = viewport.Bounds;
            UpdateMatrix();
        }

        public Matrix GetTransformMatrix()
        {
            return this.transform;
        }

        public Rectangle GetWindowBounds()
        {
            return this.bounds;
        }

        public Rectangle GetVisibleArea()
        {
            return this.visibleArea;
        }
    }
}