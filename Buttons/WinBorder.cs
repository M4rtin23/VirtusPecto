using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class WinBorder{
		public Texture2D[] SpriteIndex;
		public Vector2 Position;
		public bool State;
		public GameWindow window;
		public WinBorder(int x, int y){
			SpriteIndex = new Texture2D[2];
			Position = new Vector2(x, y);
		}
		public void Collision() {
			ToSpriteIndex(Sprite3, SpriteIndex, 2);
			if (mouse.GetCollision.Intersects(new Rectangle((int)Position.X,(int) Position.Y, 32, 32))) {
				if (mouse.GetMouseState.RightButton == ButtonState.Pressed) {
					System.Threading.Thread.Sleep(50);
					//window.IsBorderless = !window.IsBorderless;
					State = !State;
					graphics.ApplyChanges();
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(SpriteIndex[Convert.ToInt16(!State)], Position, Color.White);
			spriteBatch.DrawString(Font, "Border", new Vector2(Position.X,Position.Y-32), Color.White);
		}
    }
}
