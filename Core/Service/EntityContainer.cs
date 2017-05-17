using System.Collections.Generic;
using System.Linq;
using Core.Entity;
using Microsoft.Xna.Framework;
using Core.Entity.Component.PlayerComponents;
using Core.Entity.Component.BulletComponents;
using Microsoft.Xna.Framework.Graphics;
using Core.Entity.Component.EnemyComponents;
using Core.Entity.Component.ButtonComponents;
using Microsoft.Xna.Framework.Input.Touch;

namespace Core.Service
{
    public class EntityContainer
    {
       private  List<EntityObjectBase> Entities { get; set; }
       private  List<EntityInputObject> PlayerEntities { get; set; }
       private  List<EntityObjectBase> BulletEntities { get; set;}
       private  List<EntityObjectBase> ShieldEntities { get; set; }
       private  List<EntityObjectBase> UserComponents { get; set; }

       public EntityContainer()
       {
            Entities = new List<EntityObjectBase>();
            PlayerEntities = new List<EntityInputObject>();
            BulletEntities = new List<EntityObjectBase>();
            ShieldEntities = new List<EntityObjectBase>();
            UserComponents = new List<EntityObjectBase>();
        }        
       public  void Initialize(GraphicsDevice graphicsDevice)
       {
            
            PlayerEntities.Add(new EntityInputObject(new Vector2((graphicsDevice.Viewport.Bounds.Right - 100) / 2, graphicsDevice.Viewport.Bounds.Bottom - 200),
                new PlayerInputComponent(),new PlayerPhysicsComponent(), new PlayerGraphicsComponent(graphicsDevice)));
            UserComponents.Add(new EntityUIObject(new Vector2(graphicsDevice.Viewport.Bounds.Right - 200, graphicsDevice.Viewport.Bounds.Top + 200),
                new ButtonGraphicsComponent(graphicsDevice),new ButtonInputComponent()));
            //create enemies
            //for (int x = 0; x >= 3; x++)
            //{
            //    for (int y = 0; y >= 4; y++)
            //    {
            //        var X = 100 + (110 * x);
            //        var Y = 100 + (160 * y);
            //        var entity = new EntityObject(new Vector2(15000, 0), new Vector2(x, y),
            //            new EnemyPhysicsComponent(), new EnemyGraphicsComponent(graphicsDevice));
            //        Entities.Add(entity);
            //    }

            //}
        }
       public  void Update(GameTime gameTime)    
       {
            var tCollection = TouchPanel.GetState();
            foreach (var e in tCollection)
            {
                foreach (EntityObjectBase u in UserComponents)
                {
                    u.Update(gameTime);
                    
                }
            }
            foreach (EntityInputObject p in PlayerEntities)
            {
                p.Update(gameTime);
            }
            foreach (EntityObjectBase s in ShieldEntities)
            {
                if (CheckForBulletCollision(s))
                {
                    ShieldEntities.Remove(s);
                    continue;
                }
                s.Update(gameTime);
            }
            foreach (EntityObjectBase e in Entities)
            {
                if (CheckForBulletCollision(e))
                {
                    
                    Entities.Remove(e);
                    continue;
                }
                
                e.Update(gameTime);
            }
                     
            foreach (EntityObjectBase b in BulletEntities)
            {
                b.Update(gameTime);
            }                                                   
       }

        public  void Draw(SpriteBatch spriteBatch)
        {
            foreach (EntityInputObject p in PlayerEntities)
            {
                p.Draw(spriteBatch);
            }
            foreach (EntityObjectBase s in ShieldEntities)
            {                
                s.Draw(spriteBatch);
            }
            foreach (EntityObjectBase e in Entities)
            {
                e.Draw(spriteBatch);
            }
            foreach (EntityObjectBase u in UserComponents)
            {
                u.Draw(spriteBatch);
            }
            foreach (EntityObjectBase b in BulletEntities)
            {
                b.Draw(spriteBatch);
            }
        }

        private  bool CheckForBulletCollision(EntityObjectBase entityOne)
        {
            foreach (EntityObjectBase entityTwo in BulletEntities)
            {
                if (entityOne.X >= entityTwo.Rectangle().Left && entityOne.X <= entityTwo.Rectangle().Right
                && entityOne.Y >= entityTwo.Rectangle().Top && entityOne.X <= entityTwo.Rectangle().Bottom)
                {                                       
                    BulletEntities.Remove(entityTwo);
                    return true;
                }                
            }
            return false;    
        }

        public  void AddBullet(GraphicsDevice graphicsDevice)
        {
            if (BulletEntities.Count == 3)
               return;
            var playerRec = PlayerEntities.FirstOrDefault().Rectangle();
            var vector = new Vector2(playerRec.Center.X, playerRec.Y + 5);
            var bullet = new EntityAutomationObject(vector, new BulletPhysicsComponent(), new BulletGraphicsComponent(graphicsDevice));
            BulletEntities.Add(bullet);
            
        }
        private  void BulletOutOfRange(EntityObjectBase bullet)
        {
            var bulletRectangle = bullet.Rectangle();
            
        }
        
        
    }
}