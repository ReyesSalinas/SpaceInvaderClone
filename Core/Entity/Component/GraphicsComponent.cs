using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Entity.Component
{
    public abstract class GraphicsComponent
    {
        public Animation currentAnimation { get; set; }
        public List<Animation> Animations { get; set; }
        public Texture2D characterSheetTexture;

        public GraphicsComponent()
        {
            Animations = new List<Animation>();
        }

        public virtual void Update(EntityObjectBase entity, GameTime gameTime)
        {           
           
        }

        public virtual void Draw(EntityObjectBase entity,SpriteBatch spriteBatch)
        {
            var topLeftOfSprite = new Vector2(entity.X, entity.Y);
            Color tintColor = Color.White;
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, sourceRectangle, Color.White);
        }
    }
}