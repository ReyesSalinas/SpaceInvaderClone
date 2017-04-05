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
using Microsoft.Xna.Framework;

namespace Core.Entity
{
    public class EntityUIObject:EntityObjectBase
    {
        InputComponent Input { get; set; }
        public EntityUIObject(Vector2 startPosition,GraphicsComponent graphics,InputComponent input):base(startPosition,graphics)
        {
        }
    }
}