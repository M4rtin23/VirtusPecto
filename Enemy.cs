using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Enemy{
		public Vector2 Position;
		public Texture2D SpriteIndex;
		public Rectangle GetCollision;
		private SpriteEffects effect = SpriteEffects.None;
		//public float ImageIndex;
        public Enemy(int x,int y){
			SpriteIndex = Sprite0[0];
			Position = new Vector2(x, y);
		}
		public void Update() {
			GetCollision = new Rectangle((int)Position.X,(int) Position.Y, 128, 128);
		}
		public void Draw() {
            spriteBatch.Draw(SpriteIndex, Position, new Rectangle(0, 0, 128, 128), Color.White, 0, new Vector2(64, 64), new Vector2(1, 1), effect, 1f/Position.Y);
            
		}
		public void Follow(Vector2 objPosition, Vector2 selfPosition){
            if (objPosition.X - 64 > Position.X){
                this.Position.X += 3;
            }
            else
            if (objPosition.X + 64 < Position.X){
                Position.X -= 3;
            }
            if (objPosition.Y - 64 > Position.Y){
                Position.Y += 3;
            }
            else
            if (objPosition.Y + 64 < Position.Y){
                Position.Y -= 3;
            }
        }
    }
}
