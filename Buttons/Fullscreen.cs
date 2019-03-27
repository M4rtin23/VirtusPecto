using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Fullscreen{
		public Texture2D[] SpriteIndex;
		public Vector2 Position;
		public bool State;
		public Fullscreen(int x, int y){
			SpriteIndex = new Texture2D[2];
			ToSpriteIndex(Sprite3, SpriteIndex, 2);
            Position = new Vector2(x, y);
		}
		public void Collision() {
			if (mouse.GetCollision.Intersects(new Rectangle((int)Position.X,(int) Position.Y, 32, 32))) {
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					graphics.IsFullScreen = !graphics.IsFullScreen;
                    System.Threading.Thread.Sleep(50);
					graphics.ApplyChanges();
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(SpriteIndex[Convert.ToInt16(graphics.IsFullScreen)], Position, Color.White);
			spriteBatch.DrawString(Font, "Fullscreen", new Vector2(Position.X,Position.Y-32), Color.White);
		}
    }
}
