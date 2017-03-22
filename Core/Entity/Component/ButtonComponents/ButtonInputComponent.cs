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
        public ButtonInputComponent() : base()
        {

        }
        public override void Update(EntityObject entity)
        {                       
            entity.Velocity = TouchPanelWork(entity); 
        }
        protected Vector2 TouchPanelWork(EntityObject entity)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                var touch = touchCollection.FirstOrDefault(x => x.Position.X >= entity.X && x.Position.X <= (entity.X + entity.Rectangle().Width)
                     && x.Position.Y >= entity.Y && x.Position.Y <= (entity.Y + entity.Rectangle().Height)).Position;
                if (touch != null)
                {
                    return touch;
                }

            }
            return new Vector2();
            
        }
    }
}