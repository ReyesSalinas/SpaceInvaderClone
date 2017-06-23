using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

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
        public override void Update(EntityObjectBase entity, GameTime gameTime)
        {          
                  
        }

        public override void Draw(EntityObjectBase entity, SpriteBatch spriteBatch)
        {
            var topLeftofSprite = new Vector2(entity.X, entity.Y);                               
            var sourceRectangle =  Animations.FirstOrDefault().CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, topLeftofSprite, sourceRectangle, Color.White);            
        }
    }
}