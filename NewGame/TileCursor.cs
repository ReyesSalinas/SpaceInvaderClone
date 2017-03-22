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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Core;

namespace KnightInvaders
{
  
    public class TileCursor
    {
        static Texture2D characterSheetTexture;
        public float X { get; set; }
        public float Y { get; set; }
        Animation blinkingSquare;
        Vector2 LastLocation;

        Animation currentAnimation;

        public TileCursor(GraphicsDevice graphicsDevice)
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/RedTile.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            blinkingSquare = new Animation();
            blinkingSquare.AddFrame(new Rectangle(0, 0, 50, 50), TimeSpan.FromSeconds(.15));
            blinkingSquare.AddFrame(new Rectangle(170, 0, 50, 50), TimeSpan.FromSeconds(.15));
            LastLocation = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            var location = GetTouchLocation();
            if(location.X == 0 && location.Y == 0)
            {
                 location = LastLocation;
            }
            X = location.X;
            Y = location.Y;
            LastLocation = location;

            blinkingSquare.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var topLeftOfSprite = new Vector2(X, Y);
            Color tintColor = Color.White;
            var sourceRectangle = blinkingSquare.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, Color.White);
        }

        private Vector2 GetTouchLocation()
        {
            Vector2 touchLocation = new Vector2();
            TouchCollection touchCollection = TouchPanel.GetState();
            if(touchCollection.Count >0)
            {
                touchLocation.X = touchCollection[0].Position.X;
                touchLocation.Y = touchCollection[0].Position.Y;
                
            }
            //if(touchLocation.X != 0 || touchLocation.Y !=0)
            //{
            //    touchLocation.Normalize();
            //    const float desiredSpeed = 200;
            //    touchLocation *= desiredSpeed;
            //}
            return touchLocation;
        }   

    }
}