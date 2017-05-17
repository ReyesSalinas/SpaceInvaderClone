using Microsoft.Xna.Framework;

namespace Core.Entity.Component.PlayerComponents
{
    public class PlayerPhysicsComponent:PhysicsComponent
    {
        public override void Update(EntityObjectBase entity, GameTime gameTime)
        {
            entity.X += entity.Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //entity.Y += entity.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        
    }
}