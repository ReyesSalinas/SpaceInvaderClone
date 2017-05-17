using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.Entity.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Entity
{
    public class EntityObjectBase
    {
        protected GraphicsComponent Graphics { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public Vector2 Velocity { get; set; }
        public EntityObjectBase(Vector2 startPosition,GraphicsComponent graphics)
        {
            X = startPosition.X;
            Y = startPosition.Y;

            Graphics = graphics;
        }

        public virtual void Update(GameTime gameTime)
        {
            Graphics.Update(this,gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Draw(this, spriteBatch);
        }

        public Rectangle Rectangle()
        {
            return Graphics.currentAnimation.CurrentRectangle;
        }

    }
}