using Core.Entity.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Entity
{
    public class EntityInputObject : EntityAutomationObject
    {
        private InputComponent _input;
        public EntityInputObject(Vector2 startPosition, InputComponent input, PhysicsComponent physics, GraphicsComponent graphics) : 
            base(startPosition, physics, graphics)
        {
            _input = input;
           
        }
        public override void Update(GameTime gameTime)
        {
            _input.Update(this);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}