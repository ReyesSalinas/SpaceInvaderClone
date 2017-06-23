using Microsoft.Xna.Framework.Input.Touch;

namespace Core.Entity.Component
{
    public abstract class InputComponent
    {

        public virtual void Update(EntityObjectBase entity,TouchLocation touch)
        { 
                       
        }
        public virtual void Update(EntityObjectBase entity)
        {

        }
    }
}