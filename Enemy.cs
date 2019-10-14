using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
    public class Enemy : GameBuilder.ObjectBuilder{
        bool m = false;
		//public float ImageIndex;
        public Enemy(int x,int y){
            if(x <= 0){
                m = true;
            }
			SpriteIndex = Sprite0;
			Position = new Vector2(x, y);
		}
		public override void Update() {
            Hitbox = new Rectangle((int) Position.X - 32 + 16, (int) Position.Y - 64 + 16, 96 - 16, 128 - 16);
            if(m){
                //Follow(Levels.Player1.Position, Levels.Player1.Hitbox.Height);
            }
            base.Update();
		}
		public override void Draw(SpriteBatch sprBt) {
            center(4);
            stripToSprite(4);
            base.Draw(sprBt);
        }
		private void Follow(Vector2 objPosition, float hitboxSize){
			if(CalculateDistance(Position, objPosition) > hitboxSize && (Position.X != objPosition.X && Position.Y != objPosition.Y)){
            	float dir = (float) CalculateAngle(Position, objPosition);
				speed = CalculateVectorSpeed(3, dir);
			}else{
				speed = Vector2.Zero;
			}
		}
    }
}
