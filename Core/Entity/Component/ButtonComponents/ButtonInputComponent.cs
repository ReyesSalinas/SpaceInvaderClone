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
        public override void Update(EntityObjectBase entity)
        {    
                 
            entity.Velocity = TouchPanelWork(entity);
            
        }
        protected Vector2 TouchPanelWork(EntityObjectBase entity)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                var touch = touchCollection.FirstOrDefault(x => x.Position.X >= entity.X && x.Position.X <= (entity.X + entity.Rectangle().Width)
                     && x.Position.Y >= entity.Y && x.Position.Y <= (entity.Y + entity.Rectangle().Height));
                if (touch != null)
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