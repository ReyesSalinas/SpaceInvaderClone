using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Core.Entity.Component.ShieldComponents
{
    class ShieldGraphicsComponent:GraphicsComponent
    {
        public ShieldGraphicsComponent(GraphicsDevice graphicsDevice) : base()
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/RedTile.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            var fullShield = new Animation();
            fullShield.AddFrame(new Rectangle(0, 0, 50, 50), TimeSpan.FromSeconds(.15));
            var halfShield = new Animation();
            halfShield.AddFrame(new Rectangle(170, 0, 50, 50), TimeSpan.FromSeconds(.15));
            Animations.Add(fullShield);
            Animations.Add(halfShield);
        }       

        public override void Draw(EntityObjectBase entity, SpriteBatch spriteBatch)
        {
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, sourceRectangle.Location.ToVector2(), sourceRectangle, Color.White);
        }
    }
}