using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace Core.Entity.Component.PlayerComponents
{
    public class PlayerInputComponent : InputComponent
    {
        public PlayerInputComponent() : base()
        {

        }
        public override void Update(EntityObjectBase entity)
        {
           
            entity.Velocity = GetDesiredVelocityFromInput(entity); //desiredVelocity;
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

        Vector2 GetDesiredVelocityFromInput(EntityObjectBase entity)
        {
            Vector2 desiredVelocity = new Vector2();
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {

                desiredVelocity.X = touchCollection[0].Position.X - entity.X;
        
            }
            if (desiredVelocity.X != 0 )
            {
                desiredVelocity.Normalize();
                const float desiredSpeed = 800;
                desiredVelocity *= desiredSpeed;
            }
            return desiredVelocity;
        }
    }
}