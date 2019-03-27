using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class CardDescription{
		public Texture2D[] SpriteIndex;
		public Vector2 Position;
		private bool state = true;
		public CardDescription(int x, int y){
			SpriteIndex = new Texture2D[2];
			ToSpriteIndex(Sprite3, SpriteIndex, 2);
            Position = new Vector2(x, y);
		}
		public void Collision() {
            IsDescriptionOn = state;
			if (mouse.GetCollision.Intersects(new Rectangle((int)Position.X,(int) Position.Y, 32, 32))) {
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
                    state = !state;
                    System.Threading.Thread.Sleep(50);
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(SpriteIndex[Convert.ToInt16(state)], Position, Color.White);
			spriteBatch.DrawString(Font, "Show Description", new Vector2(Position.X,Position.Y-32), Color.White);
		}
    }
}
