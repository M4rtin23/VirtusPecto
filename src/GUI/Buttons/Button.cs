using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Button{
		public RectangleF Hitbox{get => new RectangleF(position.X, position.Y,128,32);}
		public Vector2 position = Vector2.Zero;
		protected int transparency = 0;
		protected bool checker;
        protected Action action;
        protected string name;

        public Button(string name, Action action){
            this.action = action;
            this.name = name;
        }

		public virtual void Update(float x, float y){
			position = new Vector2(x, y);
			if (Hitbox.Contains(Mouse1.Position)){
				transparency = 64;
				GameMouse.Click(action, ref checker);
			}
			else{
				transparency = 0;
			}
		}
		public virtual void Draw(SpriteBatch batch){
			Hitbox.Draw(batch, new Color(transparency, transparency, transparency, transparency));
			batch.DrawString(FontNormal, name, position, Color.White);
		}
	}
}
