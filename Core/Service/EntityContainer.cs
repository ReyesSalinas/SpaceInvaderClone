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
       private  List<EntityAutomationObject> BulletEntities { get; set;}
       private  List<EntityObjectBase> ShieldEntities { get; set; }
       private  List<EntityUIObject> UserComponents { get; set; }
       private GraphicsDevice graphicsDevice;
       public EntityContainer()
       {
            Entities = new List<EntityObjectBase>();
            PlayerEntities = new List<EntityInputObject>();
            BulletEntities = new List<EntityAutomationObject>();
            ShieldEntities = new List<EntityObjectBase>();
            UserComponents = new List<EntityUIObject>();
        }        
       public  void Initialize(GraphicsDevice graphicsDevice)
       {
            this.graphicsDevice = graphicsDevice;
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
       public void Update(GameTime gameTime)    
       {
            var tCollection = TouchPanel.GetState();
            if (tCollection.Count > 0)
            {
                foreach (var touch in tCollection)
                {
                    foreach (EntityUIObject u in UserComponents)
                    {
                        u.Update(gameTime, touch);
                        if (InputService.CurrentInput == InputType.Button)
                        {
                            continue;
                        }
                        foreach (EntityInputObject p in PlayerEntities)
                        {
                            p.Update(gameTime, touch);
                        }
                    }
                }

             
            }
            else
            {
                foreach (EntityUIObject u in UserComponents)
                {
                    u.Update(gameTime);
                }
            }
            //foreach (EntityObjectBase e in Entities)
            //{
            //    if (CheckForBulletCollision(e))
            //    {

            //        Entities.Remove(e);
            //        continue;
            //    }

            //    e.Update(gameTime);
            //}

            if (InputService.CurrentAction == UserAction.Shoot)
            {
                AddBullet(graphicsDevice);
                InputService.CurrentAction = UserAction.None;
            }
            BulletOutOfRange();
            if(BulletEntities.Count > 0 )
            {
                foreach (EntityAutomationObject b in BulletEntities)
                {
                    b.Update(gameTime);
                }
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

        private bool CheckForBulletCollision(EntityObjectBase entityOne)
        {
            foreach (EntityAutomationObject entityTwo in BulletEntities)
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

        public void AddBullet(GraphicsDevice graphicsDevice)
        {
            if (BulletEntities.Count == 9)
            {
                return;
            }
            
            var playerRec = PlayerEntities.FirstOrDefault();

            var velocity = new Vector2(0, 300);
            var startposition = new Vector2(playerRec.X, playerRec.Y);
            foreach (EntityAutomationObject e in BulletEntities)
            {
                if ( e.X <= startposition.X && e.Y <= startposition.Y &&
                   (e.X + 50) >= startposition.X && (e.Y + 50) >= startposition.Y)
                {
                    return;
                }
            }
            
            var bullet = new EntityAutomationObject(velocity,startposition, new BulletPhysicsComponent(), new BulletGraphicsComponent(graphicsDevice));
           
            BulletEntities.Add(bullet);

            
        }
        private void BulletOutOfRange()
        {
            BulletEntities.RemoveAll(bullet => bullet.X < 0 || bullet.Y < 0 ||
                bullet.X > graphicsDevice.Viewport.Bounds.Right || bullet.Y > graphicsDevice.Viewport.Bounds.Bottom);
           

            
        }
        
        
    }
}