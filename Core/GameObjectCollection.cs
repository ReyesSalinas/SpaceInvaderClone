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
using Microsoft.Xna.Framework;

namespace Core
{
    class GameObjectCollection
    {
        private static Dictionary<int, ISprite> GameObjects { get; set; }
        
        public static KeyValuePair<int, ISprite> ActivatedObject {get;set;}
        public static void ActivateObject(int objectID)
        {
            ActivatedObject = GameObjects.FirstOrDefault(x => x.Key == objectID);            
            
        }
    }
}