using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Joystick{
		public Vector2 Position;
		private bool state;
        public Joystick(float x, float y){
            state = IsJoy;
            Position = new Vector2(x, y);
        }
        public void Update(){
            if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
                state = true;
            }
            IsJoy = state;
            if (mouse.GetCollision.Intersects(new Rectangle((int)Position.X,(int) Position.Y, 32, 32))) {
				if (IsClicking) {
					state = !state;
                    System.Threading.Thread.Sleep(50);
				}
			}
        }
        public void Draw(){
            spriteBatch.DrawString(Font, "Joystick", new Vector2(Position.X,Position.Y-32), Color.White);
            spriteBatch.Draw(Sprite3[Convert.ToInt16(state)], Position, Color.White);
        }
    }
}