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
        private int health = 100;
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
                speed = Follow(Levels.Player1.Position, Position, Levels.Player1.Hitbox.Height, 3);
            }
            if(health <= 0){
                Levels.DestroyEnemy();
            }
            base.Update();
		}
		public override void Draw(SpriteBatch sprBt) {
            center(4);
            stripToSprite(4);
            base.Draw(sprBt);
            if(health < 100){
                sprBt.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(64, 64, 64, 128), 0, new Vector2(0, 0), new Vector2(1, 1/4f), SpriteEffects.None, 0);
                sprBt.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(255, 0, 0, 128), 0, new Vector2(0, 0), new Vector2((float)health/100, 1/4f), SpriteEffects.None, 0);
            }
        }
        public void AddHealth(int number){
            health += number;
        }
        public int GetHealth(){
            return health;
        }
    }
}
