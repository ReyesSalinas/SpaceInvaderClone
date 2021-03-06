using Microsoft.Xna.Framework;

namespace Core.Entity.Component.BulletComponents
{
    public class BulletPhysicsComponent:PhysicsComponent
    {
        public override void Update(EntityObject entity, GameTime gameTime)
        {
            entity.Y += entity.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        
    }
}