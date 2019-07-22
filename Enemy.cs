using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
    public class Enemy{
		public Vector2 Position;
        private Vector2 speed;
		public Texture2D SpriteIndex;
		public Rectangle GetCollision;
		private SpriteEffects effect = SpriteEffects.None;
        bool m = false;
		//public float ImageIndex;
        public Enemy(int x,int y){
            if(x <= 0){
                m = true;
            }
			SpriteIndex = Sprite0;
			Position = new Vector2(x, y);
		}
		public void Update() {
            Position += speed;
            GetCollision = new Rectangle((int) Position.X - 32 + 16, (int) Position.Y - 64 + 16, 96 - 16, 128 - 16);
            if(m){
                //Follow(Levels.Player1.Position, Levels.Player1.GetCollision.Height);
            }
		}
		public void Draw(SpriteBatch sprBt) {
            //GameMaker.MakerObject.DrawRectangle(spriteBatch, Sprite2, GetCollision, Color.White);
            sprBt.Draw(SpriteIndex, Position, new Rectangle(0, 0, 128, 128), Color.White, 0, new Vector2(64, 64), new Vector2(1, 1), effect, 0);
		}
			private void Follow(Vector2 objPosition, float hitboxSize){
			if(CalculateDistance(Position, objPosition) > hitboxSize && (Position.X != objPosition.X && Position.Y != objPosition.Y)){
            	float dir = (float) CalculateAngle(Position, objPosition);
				speed.Y = (float) CalculateVspeed(3, dir);
				speed.X = (float) CalculateHspeed(3, dir);
			}else{
				speed.X = 0;
				speed.Y = 0;
			}
		}
    }
}
