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

namespace Core.Entity.Component.ButtonComponents
{
    public class ButtonInputComponent : InputComponent
    {
        Vector2 currentTouch;
        public ButtonInputComponent() : base()
        {

        }
        public override void Update(EntityObjectBase entity,TouchLocation touch)
        {    
                 
            entity.Velocity = TouchPanelWork(entity,postion);
            
        }
        protected Vector2 TouchPanelWork(EntityObjectBase entity,TouchLocation touch)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                if(entity.Rectangle().Contains((int)touch.Position.X,(int)touch.Postion.Y))
                {               
                    Vector2 currentVelocity = touch.Position;                    
                    touchCollection.Remove(touch);
                    return currentVelocity;
                }              

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