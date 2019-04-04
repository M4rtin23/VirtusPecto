using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class OptionBox{
        protected string name;
		protected Rectangle hitbox;
        public Vector2 Position;
		private Color color;
        public Vector2[] Options;
		public Color[] Colors;
		public bool isActivated;
		public int OptionsNumber;
        protected int number;

        public OptionBox(){
            OptionsNumber = n();
            Options = new Vector2[OptionsNumber];
			Colors = new Color[OptionsNumber];
			hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);
			for (int i = 0; i < OptionsNumber; i++){                
                Colors[i] = Color.DarkGray;
            }
		}
        protected virtual void action(int i){}
        //Don't be lazy and change it.
        //Don't be lazy and change it.
        //Don't be lazy and change it.
        //Don't be lazy and change it.
        //Don't be lazy and change it.

        protected virtual void update(){}
        protected virtual int n(){return 0;}
        public void SetPosition(float x, float y){
            Position = new Vector2(x, y);
        }
        protected virtual string drawOptions(int i){
            return null;
        }
		public void Collision() {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);
        //Don't be lazy and change it.
        //Don't be lazy and change it.
        //Don't be lazy and change it.
            update();
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
                            action(i);
                            number = i;
                            isActivated = false;
						}
						Colors[i] = Color.LightBlue;
                    }else{
						Colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(Sprite2, Position, color);
            spriteBatch.DrawString(Font, drawOptions(number), Position, Color.White);
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
