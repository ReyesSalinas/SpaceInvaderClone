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
    public interface ISprite
    {
        Texture2D SpriteSheet { get; set; }
        IEnumerable<Animation> Animations { get; set; }
        Vector2 Position {get;set;}

    }
    public class CharacterEntity
    {
        static Texture2D characterSheetTexture;
        public float X { get; set; }
        public float Y { get; set; }
        Animation walkDown;
       

        Animation currentAnimation;

        public CharacterEntity(Vector2 startPos,GraphicsDevice graphicsDevice)
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/Warrior.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(115, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(212, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(310, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(404, 10, 92, 150), TimeSpan.FromSeconds(.15));

        }

        public void Update(GameTime gameTime)
        {
            var velocity = GetDesiredVelocityFromInput();
            X += velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Y += velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if ((velocity.X == X && velocity.Y == Y))
            {
                currentAnimation = walkDown;
                currentAnimation.Update(gameTime);
            }
            // lower and left
            if (velocity.X >= X && velocity.Y >= Y)
            {
                currentAnimation = walkDown;
            }
            //higher and right
            if (velocity.X <= X && velocity.Y <= Y)
            {
                currentAnimation = walkDown;                
            }
            //lower and right
            if (velocity.X >= X && velocity.Y <= Y)
            {
                currentAnimation = walkDown;
            }
            //higher and left
            if (velocity.X <= X && velocity.Y >= Y)
            {
                currentAnimation = walkDown;
            }

            
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var topLeftOfSprite = new Vector2(X, Y);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, Color.White);
        }

        Vector2 GetDesiredVelocityFromInput()
        {
            Vector2 desiredVelocity = new Vector2();
            TouchCollection touchCollection = TouchPanel.GetState();
            if(touchCollection.Count >0)
            {
                desiredVelocity.X = touchCollection[0].Position.X - this.X;
                desiredVelocity.Y = touchCollection[0].Position.Y - this.Y;
            }
            if(desiredVelocity.X != 0 || desiredVelocity.Y !=0)
            {
                desiredVelocity.Normalize();
                const float desiredSpeed = 200;
                desiredVelocity *= desiredSpeed;
            }
            return desiredVelocity;
        }   

    }

   
}