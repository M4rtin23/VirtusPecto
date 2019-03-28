using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class TickBox{
        protected string name;
		protected Vector2 position;
		public bool state;
		public void Collision() {
            update();
			if (mouse.GetCollision.Intersects(new Rectangle((int)position.X,(int) position.Y, 32, 32))) {
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
                    state = !state;
					action();
                    System.Threading.Thread.Sleep(50);
				}
			}
		}
        public void SetPosition(float x, float y){
            position = new Vector2(x, y);
        }
        protected virtual void action(){
        }
        protected virtual void update(){

        }
		public void Draw() {
			spriteBatch.Draw(Sprite3[Convert.ToInt16(state)], position, Color.White);
			spriteBatch.DrawString(Font, name, position + new Vector2(0,-32), Color.White);
		}
    }
}
