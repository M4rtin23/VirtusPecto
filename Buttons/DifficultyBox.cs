using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class DifficultyBox{
		public Rectangle GetCollision;
        public Texture2D BoxSprite;
        public Vector2 BoxPosition;
        public Color color;
		public String[] Options;
        public Color[] Colors;
        public Rectangle[] Rectangles;
        public bool isActivated;
        public int OptionsNumber;
		public string Difficulty;

        public DifficultyBox(int x, int y){
            BoxSprite = Sprite2;
			Difficulty = "Normal";
			OptionsNumber = 3;
			Options = new String[OptionsNumber];
            color = Color.LightGray;
            Colors = new Color[OptionsNumber];
            Rectangles = new Rectangle[OptionsNumber];
            BoxPosition = new Vector2(x,y);
            GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);

			Options[0] = "Easy";
			Options[1] = "Normal";
			Options[2] = "Difficult";

			for (int i = 0; i < OptionsNumber; i++){
                Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (1 + i) * 32, 128, 32);
                Colors[i] = Color.DarkGray;
            }
		}
		public void Collision(){
            GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);
            if(IsClicking && isActivated){
            }
            if (GetCollision.Intersects(mouse.GetCollision) && IsClicking){
                isActivated = !isActivated;
                System.Threading.Thread.Sleep(50);
            }
            
            if (isActivated){
                for (int i = 0; i < OptionsNumber; i++){
                    if (mouse.GetCollision.Intersects(Rectangles[i])){
                        if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
							Difficulty = Options[i];
                            isActivated = false;
                        }
                        Colors[i] = Color.LightBlue;
                    }else{
                        Colors[i] = Color.DarkGray;
                    }
                }
            }
        }
		public void Draw(){
            spriteBatch.Draw(BoxSprite, BoxPosition, color);
			spriteBatch.DrawString(Font, " " + Difficulty, BoxPosition, Color.White);
            if (isActivated){
                color = Color.LightGray;
                for (int i = 0; i < OptionsNumber; i++){
                    spriteBatch.Draw(BoxSprite, new Vector2(BoxPosition.X, BoxPosition.Y + (1 + i) * 32), Colors[i]);
					spriteBatch.DrawString(Font, Options[i], new Vector2(BoxPosition.X, BoxPosition.Y + (i + 1) * 32), Color.White);
                }
            }else{
                color = Color.DarkGray;
            }
        }
    }
}
