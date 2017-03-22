using Microsoft.Xna.Framework;
using Core.Entity.Component;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Entity
{
    public class EntityObject
    {
       
        private PhysicsComponent _physics;
        private GraphicsComponent _graphics;

        public Vector2 Velocity { get;  set; }
        public float X { get;  set; }
        public float Y { get;  set; }

        public EntityObject(Vector2 startPosition,PhysicsComponent physics,GraphicsComponent graphics)
        {
            X = startPosition.X;
            Y = startPosition.Y;
            
            _physics = physics;
            _graphics = graphics;
        }
        public EntityObject(Vector2 velocity, Vector2 startPosition, PhysicsComponent physics, GraphicsComponent graphics)
        {
            X = startPosition.X;
            Y = startPosition.Y;
            Velocity = velocity;
            _physics = physics;
            _graphics = graphics;
        }
        public virtual void Update(GameTime gameTime)
        {            
            _physics.Update(this, gameTime);
            _graphics.Update(this, gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            _graphics.Draw(this, spriteBatch);
        }
        public Rectangle Rectangle()
        {
            return _graphics.currentAnimation.CurrentRectangle;
        }


        
    }
}