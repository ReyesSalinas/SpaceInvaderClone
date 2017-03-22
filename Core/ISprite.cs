using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface ISprite
    {
        int  ID { get; set; }
        Texture2D SpriteSheet { get; set; }
        
        float Width { get; set; }
        float Height { get; set; }
        IEnumerable<Animation> Animations { get; set; }
    }


}
