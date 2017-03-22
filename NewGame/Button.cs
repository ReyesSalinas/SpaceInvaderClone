using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace KnightInvaders
{

    public class Button
    {
        static Texture2D characterSheetTexture;
        public float X { get; set; }
        public float Y { get; set; }
        private Animation buttonUp;
        private Animation buttonDown;
        Vector2 LastLocation;
       
       
        Animation currentAnimation;

        public Button(GraphicsDevice graphicsDevice)
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/MoveButtonBIG.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            buttonUp = new Animation();
            buttonDown = new Animation();
            buttonUp.AddFrame(new Rectangle(198, 0, 198, 200), TimeSpan.FromSeconds(.50));
            buttonDown.AddFrame(new Rectangle(0, 0, 198, 200), TimeSpan.FromSeconds(.50));
            currentAnimation = buttonUp;
            X = graphicsDevice.Viewport.Bounds.Right - 200;
            Y = graphicsDevice.Viewport.Bounds.Top + 200;
                

            LastLocation = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            var location = GetTouchLocation();
            
            currentAnimation = buttonUp;
            
            if (location.X  >= X && location.X <= (X + 198)
                && location.Y >= Y && location.Y <= (Y +200))
            {
                currentAnimation = buttonDown;
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

        private Vector2 GetTouchLocation()
        {
            
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                if (touchCollection.Any(x => x.Position.X >= X && x.Position.X <= (X + 198)
                && x.Position.Y >= Y && x.Position.Y <= (Y + 200)))
                {

                    return touchCollection.FirstOrDefault(x => x.Position.X >= X && x.Position.X <= (X + 198)
                    && x.Position.Y >= Y && x.Position.Y <= (Y + 200)).Position;
                }

            }
            return new Vector2();
        }   

    }
}