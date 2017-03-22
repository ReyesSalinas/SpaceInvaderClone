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

namespace KnightInvaders
{
    public enum SpriteState
    {
        Stand = 0,
        Walk = 1,
        Run = 2,
        Defend = 3,
        Attack = 4,
        KnockDown = 5,
        Dead = 6
    }
    public enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2, 
        Right = 3
    }
    public static class KnightAnimationService
    {
        public static Animation GetAnimation(CharacterEntity character,SpriteState spriteState,Direction direction)
        {
            return new Animation();
        }
        static Animation Stand(CharacterEntity character, Direction direction)
        {
            switch (direction)
            { 
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();                
                default:throw new ArgumentOutOfRangeException();
            }           
        }
        static Animation Walk(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }
        static Animation Run(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        static Animation Attack(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        static Animation Defend(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }
        static Animation KnockDown(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }
        static Animation Dead(CharacterEntity character, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return new Animation();
                case Direction.Down: return new Animation();
                case Direction.Left: return new Animation();
                case Direction.Right: return new Animation();
                default: throw new ArgumentOutOfRangeException();
            }
        }
     

    }
}