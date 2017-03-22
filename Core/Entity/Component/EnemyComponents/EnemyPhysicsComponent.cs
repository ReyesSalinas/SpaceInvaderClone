using Microsoft.Xna.Framework;

namespace Core.Entity.Component.EnemyComponents
{
    public class EnemyPhysicsComponent:PhysicsComponent
    {
        
        public override void Update(EntityObject entity, GameTime gameTime)
        {
            if (entity.X > 600)
            {
                entity.Velocity = -entity.Velocity;
                entity.Y += 20;
            }
            if (entity.X < 100)
            {
                entity.Velocity = -entity.Velocity;
                entity.Y += 20;
            }
            entity.X += entity.Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //entity.Y += entity.Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        
        
    }
}