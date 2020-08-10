using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class TickBox{
		protected string name;
		protected Vector2 position;
		protected virtual bool state{get; set;}
		bool checker;
		public void Collision() {
			if(new Rectangle((int)position.X,(int) position.Y, 32, 32).Contains(Mouse1.Position)){
				if(IsClicking){
					checker = true;
				}else if(checker) {
					state = !state;
					checker = false;
				}
			}else{
				checker = false;
			}
		}
		public void SetPosition(float x, float y){
			position = new Vector2(x, y);
		}
		
		public void Draw(SpriteBatch batch) {
			batch.Draw(SpriteTick, position, new Rectangle(Convert.ToInt16(state) * 32,0,32,32), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
			batch.DrawString(FontNormal, name, position + new Vector2(0,-32), Color.White);
		}
	}
}
