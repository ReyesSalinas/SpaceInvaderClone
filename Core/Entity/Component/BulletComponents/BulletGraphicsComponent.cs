using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Core.Entity.Component.BulletComponents
{
    public class BulletGraphicsComponent:GraphicsComponent
    {
        

        public BulletGraphicsComponent(GraphicsDevice graphicsDevice) : base()
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/RedTile.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            var blinkingSquare = new Animation();
            blinkingSquare.AddFrame(new Rectangle(0, 0, 50, 50), TimeSpan.FromSeconds(.15));
            blinkingSquare.AddFrame(new Rectangle(170, 0, 50, 50), TimeSpan.FromSeconds(.15));
            Animations.Add(blinkingSquare);
        }
        public override void Update(EntityObject entity, GameTime gameTime)
        {          
                       
        }

        public override void Draw(EntityObject entity, SpriteBatch spriteBatch)
        {                    
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, sourceRectangle.Location.ToVector2(), sourceRectangle, Color.White);            
        }
    }
}