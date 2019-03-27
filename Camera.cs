using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Camera{
        public static Matrix Transform;
        public void Follow(Vector2 o) {
            Transform = Matrix.CreateTranslation(-o.X-128,  -o.Y, 0)*Matrix.CreateTranslation(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight/2,0);
        }
    }
}