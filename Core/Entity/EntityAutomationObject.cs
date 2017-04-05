using Microsoft.Xna.Framework;
using Core.Entity.Component;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Entity
{
    public class EntityAutomationObject:EntityObjectBase
    {
       
        private PhysicsComponent Physics { get; set; }
      

        public Vector2 Velocity { get;  set; }
       

        public EntityAutomationObject(Vector2 startPosition,PhysicsComponent physics,GraphicsComponent graphics):base(startPosition,graphics)
        {     
            
            Physics = physics;
            Graphics = graphics;
        }
        public EntityAutomationObject(Vector2 velocity, Vector2 startPosition, PhysicsComponent physics, GraphicsComponent graphics)
        {
            X = startPosition.X;
            Y = startPosition.Y;
            Velocity = velocity;
            Physics = physics;
            Graphics = graphics;
        }
        public virtual void Update(GameTime gameTime)
        {            
            Physics.Update(this, gameTime);
            Graphics.Update(this, gameTime);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Draw(this, spriteBatch);
        }
        public Rectangle Rectangle()
        {
            return Graphics.currentAnimation.CurrentRectangle;
        }


        
    }
}