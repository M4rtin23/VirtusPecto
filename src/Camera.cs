using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Camera{
//        public static Matrix Transform;
        public static Matrix Follow(Vector2 o) {
            //Transform = 
            return Matrix.CreateTranslation(-o.X,  -o.Y, 0)*Matrix.CreateTranslation(Width()/2, Height()/2,0);
        }
    }
}