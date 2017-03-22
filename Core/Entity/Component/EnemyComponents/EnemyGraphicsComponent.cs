using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Core.Entity.Component.EnemyComponents
{
    public class EnemyGraphicsComponent:GraphicsComponent
    {
        float playerHeight;      
        public EnemyGraphicsComponent(GraphicsDevice graphicsDevice) : base()
        {
            using (var stream = TitleContainer.OpenStream("Resources/Content/Warrior.png"))
            {
                characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
            }
            //need to bundle this up somewhere else as well but can be here for now
            playerHeight = graphicsDevice.Viewport.Bounds.Bottom - 200;
            Animations = new List<Animation>();
            var walkDown = new Animation();
            walkDown.AddFrame(new Rectangle(115, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(212, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(310, 10, 92, 150), TimeSpan.FromSeconds(.15));
            walkDown.AddFrame(new Rectangle(404, 10, 92, 150), TimeSpan.FromSeconds(.15));
            currentAnimation = walkDown;
            Animations.Add(walkDown);
        }
        public override void Update(EntityObject entity, GameTime gameTime)
        {
            
            currentAnimation.Update(gameTime);
        }

        public override void Draw(EntityObject entity, SpriteBatch spriteBatch)
        {
            var topLeftOfSprite = new Vector2(entity.X, playerHeight);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, Color.White);
        }
    }
}