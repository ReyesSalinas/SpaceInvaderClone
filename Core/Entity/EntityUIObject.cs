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
    public class EntityUIObject:EntityObjectBase
    {
        InputComponent Input { get; set; }
        public EntityUIObject(Vector2 startPosition,GraphicsComponent graphics,InputComponent input):base(startPosition,graphics)
        {
            Input = input;
        }

        public override void Update(GameTime gameTime)
        {

            Input.Update(this);
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}