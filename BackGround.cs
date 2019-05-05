using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class BackGround{
        private Texture2D backGround;
        private Vector2 position;
        public BackGround(Texture2D texture){
            backGround = texture;
            position = new Vector2(0, 0);
        }
        public void Draw(){
            int width = backGround.Width, height = backGround.Height;
            int x1 = (int)Math.Ceiling((decimal)graphics.PreferredBackBufferWidth/width);
            int y1 = (int)Math.Ceiling((decimal)graphics.PreferredBackBufferHeight/height);
            for(int x = -x1/2-2; x < x1/2+2; x++){
                position.X = (width*((int)(Levels.Player1.Position.X/width))) + width * x;
                for(int y = -y1/2-1; y < y1/2+1; y++){
                    position.Y = (height*((int)(Levels.Player1.Position.Y/height))) + height * y;
                    spriteBatch.Draw(backGround, position, null, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0);
                }
            }
        }
    }
}