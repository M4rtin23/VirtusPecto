using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class TickBox : Box{
		protected string name;
		protected Vector2 position;

		public TickBox(string name, bool state){
			this.name = name;
			State = state;
		}

		public override void Update(float x, float y){
			position = new Vector2(x, y);
			if(new Rectangle((int)position.X,(int) position.Y, 32, 32).Contains(GameMouse.Position)){
				Mouse1.Click(() => {State = !State;});
			}
		}

		public override void Draw(SpriteBatch batch) {
			batch.Draw(SpriteTick, position, new Rectangle(Convert.ToInt16(State) * 32,0,32,32), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
			batch.DrawString(FontNormal, name, position + new Vector2(0,-32), Color.White);
		}
	}
}
