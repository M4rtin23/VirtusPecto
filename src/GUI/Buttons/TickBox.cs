using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class TickBox{
		protected string name;
		protected Vector2 position;
		protected bool state = false;
		bool checker;
		
		public TickBox(string name){
			this.name = name;
		}

		public void Update(float x, float y, ref bool state){
			this.state = state;
			position = new Vector2(x, y);
			if(new Rectangle((int)position.X,(int) position.Y, 32, 32).Contains(Mouse1.Position)){
				GameMouse.Click(() => {this.state = !this.state;}, ref checker);
			}else{
				checker = false;
			}
			state = this.state;
		}
		
		public void Draw(SpriteBatch batch) {
			batch.Draw(SpriteTick, position, new Rectangle(Convert.ToInt16(state) * 32,0,32,32), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
			batch.DrawString(FontNormal, name, position + new Vector2(0,-32), Color.White);
		}
	}
}
