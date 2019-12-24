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
        bool checker;
		public void Collision() {
            update();
			if(new Rectangle((int)position.X,(int) position.Y, 32, 32).Contains(Mouse1.Position)){
                if(IsClicking()){
                    checker = true;
                }else if(checker) {
                    state = !state;
					action();
                    checker = false;
				}
			}else{
                checker = false;
            }
		}
        public void SetPosition(float x, float y){
            position = new Vector2(x, y);
        }
        protected virtual void action(){
        }
        protected virtual void update(){

        }
		public void Draw(SpriteBatch sprBt) {
//			spriteBatch.Draw(Sprite3[Convert.ToInt16(state)], position, Color.White);
            sprBt.Draw(Sprite3, position, new Rectangle(Convert.ToInt16(state) * 32,0,32,32), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
			sprBt.DrawString(Font, name, position + new Vector2(0,-32), Color.White);
		}
    }
}
