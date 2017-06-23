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

namespace Core.Service
{
    public enum InputType
    {
        PlayerMovement = 0,
        Button = 1,
        None = 99,
    }
    public enum UserAction
    {
        Shoot = 1,
        None = 0,
    }
    public static class InputService
    {
        public static List<InputType> Inputs = new List<InputType>();
        public static InputType CurrentInput { get; set; }
        public static List<UserAction> Actions = new List<UserAction>();
        public static UserAction CurrentAction { get; set; }
    }
}