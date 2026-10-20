using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class TickBox : UIElement{
		Action action;
		public TickBox(string name, bool state, Action action){
			this.name = name;
			State = state;
			this.action = action;
		}

		public override void Update(float x, float y){
			position = new Vector2(x, y);
			MouseHandler.Click(new GameBuilder.Shapes.RectangleF(position, 32),() => {State = !State;});
			action();
		}

		public override void Draw(SpriteBatch batch) {
			batch.Draw(Sprites["Tick"], position, new Rectangle(Convert.ToInt16(State) * 32,0,32,32), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
			batch.DrawString(FontNormal, name, position + new Vector2(0,-32), Color.White);
		}
	}
}
