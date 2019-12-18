using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Enemy : Entity{
        public Enemy(Vector2 pos){
			SpriteIndex = Sprite0;
			Position = pos;
            maxSpeed = 3;
		}
		public override void Update() {
            SetTarget(Levels.Creature1);
            int h = Levels.Creature1.Length;
            if(target == null && h > 0){
                SetTarget(Levels.Creature1);    
            }
            Hitbox = new Rectangle((int) Position.X - 32 + 16, (int) Position.Y - 64 + 16, 96 - 16, 128 - 16);
            if(health <= 0){
                Levels.DestroyEnemy();
            }
            if(h > 0){
                followTarget();
            }
            CheckTarget(Levels.Creature1);
            base.Update();
		}
        public override void Draw(SpriteBatch sprBt){
            base.Draw(sprBt);
            sprBt.DrawString(Font, ""+target, new Vector2(0,512), Color.White);
        }
    }
}
