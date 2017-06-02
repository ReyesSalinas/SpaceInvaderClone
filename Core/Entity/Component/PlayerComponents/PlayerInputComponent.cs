using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace Core.Entity.Component.PlayerComponents
{
    public class PlayerInputComponent : InputComponent
    {
        public const Rectangle PLAYERMOVEMENTRECTANGLE = new Rectangle(
            0,graphicsDevice.Viewport.Bounds.Bottom - 200,graphicsDevice.Viewport.Bounds.Width,100)
         const float desiredSpeed = 800;
        public PlayerInputComponent() : base()
        {

        }
        public override void Update(EntityObjectBase entity,TouchLocation touch)
        {
           
            entity.Velocity = GetDesiredVelocityFromInput(entity,touch); //desiredVelocity;
        }
        protected Vector2 TouchPanelWork(EntityObjectBase entity)
        {
            var touchCol = TouchPanel.GetState();

            foreach (var touch in touchCol)
            {
                if (touch.State != TouchLocationState.Released )
                    continue;

                TouchLocation prevLoc;

                // Sometimes TryGetPreviousLocation can fail. Bail out early if this happened
                // or if the last state didn't move
                if (!touch.TryGetPreviousLocation(out prevLoc) || prevLoc.State != TouchLocationState.Moved)
                    continue;

                // get your delta
                var delta = touch.Position - prevLoc.Position;
                // Usually you don't want to do something if the user drags 1 pixel.
                if (delta.LengthSquared() < 300)
                    continue;
                var desiredVelocity = new Vector2();
                if (delta.X < 0 || delta.Y < 0)
                    {
                        desiredVelocity.X = -12000;
                        return desiredVelocity;
                    }
                    if (delta.X > 0 || delta.Y > 0)
                    {
                        desiredVelocity.X = 12000;
                        return desiredVelocity;
                     }               

            }
            return new Vector2();
            
        }
        protected Vector2 TiltWork()
        {
     
            return new Vector2();
        }

        Vector2 GetDesiredVelocityFromInput(EntityObjectBase entity,TouchLocation touch)
        {
                Vector2 desiredVelocity = new Vector2();
                var desiredVelocity = touch.Position.X - entity.X;
                desiredVelocity.Normalize();               
                desiredVelocity *= desiredSpeed;                                     
                return desiredVelocity;
        }
    }
}