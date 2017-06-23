using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.Entity.Component;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using Core.Service;

namespace Core.Entity.Component.ButtonComponents
{
    public class ButtonInputComponent : InputComponent
    {
       
        public ButtonInputComponent() : base()
        {

        }
        public override void Update(EntityObjectBase entity)
        {
            entity.Velocity = new Vector2();
        }
        public override void Update(EntityObjectBase entity,TouchLocation touch)
        {    
                 
            entity.Velocity = TouchPanelWork(entity, touch);
            
        }
        protected Vector2 TouchPanelWork(EntityObjectBase entity,TouchLocation touch)
        {                       
                
                if(touch.Position.X >= entity.X && touch.Position.Y >= entity.Y 
                    && touch.Position.X <= (entity.X + 198) && touch.Position.Y <= (entity.Y + 200))
                {
                    Vector2 currentVelocity = new Vector2();
                    currentVelocity = touch.Position;
                  
                    return currentVelocity;
                }                         

            
            return new Vector2();
            
        }

        Vector2 Swipe(EntityObjectBase entity)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            return new Vector2();
        }
    }
}