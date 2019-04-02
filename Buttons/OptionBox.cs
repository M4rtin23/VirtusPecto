using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class OptionBox{
        private string name;
		private Rectangle hitbox;
        public Vector2 Position;
		public Color color;
        public Vector2[] Options;
		public Color[] Colors;
		//public Rectangle[] Rectangles;
		public bool isActivated;
		public int OptionsNumber;

        public OptionBox(){
			OptionsNumber = 8;
			Options = new Vector2[OptionsNumber];
			Colors = new Color[OptionsNumber];
			//Rectangles = new Rectangle[OptionsNumber];
			hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);

			for (int i = 0; i < OptionsNumber; i++){
				Options[i] = new Vector2(1366, 768);
			}
			for (int i = 0; i < OptionsNumber; i++){                
				//Rectangles[i] = new Rectangle((int)Position.X, (int)Position.Y + (1+i)*32, 128, 32);
                Colors[i] = Color.DarkGray;
            }
		}
        public void SetPosition(float x, float y){
            Position = new Vector2(x, y);
        }

        protected virtual string drawOptions(int i){
            string a = " "+Convert.ToString(Options[i].X) + " X " + Convert.ToString(Options[i].Y);
            return a;
        }
        protected virtual string setSelectedOption(){
            string a = " "+Convert.ToString(graphics.PreferredBackBufferWidth) + " X " + Convert.ToString(graphics.PreferredBackBufferHeight);
            return a;
        }
		public void Collision() {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);
            for (int i = 0; i < OptionsNumber; i++){
                //Rectangles[i] = new Rectangle((int)Position.X, (int)Position.Y + (1 + i)*32, 128, 32);
				Options[i].X = (float)Math.Ceiling(Settings.AspectRatio * Options[i].Y);
			}
			if (hitbox.Intersects(mouse.GetCollision)){
                if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
					isActivated = !isActivated;
                    System.Threading.Thread.Sleep(50);
                }
            }
			if (isActivated){
				for (int i = 0; i < OptionsNumber; i++){
                    Rectangle r = new Rectangle((int)Position.X, (int)Position.Y + (1 + i)*32, 128, 32);
					if (mouse.GetCollision.Intersects(r)){
						if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
							graphics.PreferredBackBufferWidth = (int)Options[i].X;
							graphics.PreferredBackBufferHeight = (int)Options[i].Y;
                            isActivated = false;
							graphics.ApplyChanges();
						}
						Colors[i] = Color.LightBlue;}
					else{
						Colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(Sprite2, Position, color);
            spriteBatch.DrawString(Font, setSelectedOption(), Position, Color.White);
			spriteBatch.DrawString(Font, name, new Vector2(Position.X, Position.Y - 32), Color.White);

			if (isActivated) {
				color = Color.LightGray;
				for (int i = 0; i < OptionsNumber; i++){
					spriteBatch.Draw(Sprite2, new Vector2(Position.X, Position.Y+(1+i)*32), Colors[i]);
					spriteBatch.DrawString(Font, drawOptions(i), new Vector2(Position.X, Position.Y + (i+1) * 32), Color.White);
				}

			}else{
				color = Color.DarkGray;
			}
		}
    }
}
