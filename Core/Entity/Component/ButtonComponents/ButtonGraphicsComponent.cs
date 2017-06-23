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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Core.Service;

namespace Core.Entity.Component.ButtonComponents
{
    public class ButtonGraphicsComponent:GraphicsComponent
    {
       
              
        public ButtonGraphicsComponent(GraphicsDevice graphicsDevice) : base()
        {
            if (characterSheetTexture == null)
            {
                using (var stream = TitleContainer.OpenStream("Content/MoveButtonBIG.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }

            var buttonUp = new Animation();
            var buttonDown = new Animation();
            buttonUp.AddFrame(new Rectangle(198, 0, 198, 200), TimeSpan.FromSeconds(.50));
            buttonDown.AddFrame(new Rectangle(0, 0, 198, 200), TimeSpan.FromSeconds(.50));
            Animations.Add(buttonUp);
            Animations.Add(buttonDown);
            currentAnimation = buttonUp;
        }
        public override void Update(EntityObjectBase entity, GameTime gameTime)
        {



            if (entity.Velocity.X == 0 && entity.Velocity.Y == 0)
            {
                currentAnimation = Animations[0];
                InputService.CurrentInput = InputType.None;
                InputService.CurrentAction = UserAction.None;
            }
            else
            {
                InputService.CurrentInput = InputType.Button;
                InputService.CurrentAction = UserAction.Shoot;
                if (currentAnimation.Equals(Animations[1]))
                {
                    currentAnimation.Update(gameTime);
                    return;
                }
                
                currentAnimation = Animations[1];
            }            
            currentAnimation.Update(gameTime);
        }
        

        public override void Draw(EntityObjectBase entity, SpriteBatch spriteBatch)
        {                    
            var sourceRectangle = currentAnimation.CurrentRectangle;
            var topLeftOfSprite = new Vector2(entity.X, entity.Y);
            spriteBatch.Draw(characterSheetTexture,topLeftOfSprite, sourceRectangle, Color.White);            
        }
    }
}