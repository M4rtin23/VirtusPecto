using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Enemy : Entity{
		public Enemy(Vector2 pos){
			SpriteIndex = Sprite0;
			Position = pos;
			maxSpeed = 3;
			startingPoint = pos;
		}
		public override void Update() {
			SetTarget(Level1.Creature1);
			if(health <= 0){
				Level1.DestroyEnemy();
			}

			if(isAttacking){
				followTarget();
				if(speed == Vector2.Zero && dist > 0 && dist > CalculateDistance(Position, target)/2 && (GT.TotalGameTime.Milliseconds % 1000 == 0)){
					Level1.CreateFireball(false, Position, (float)CalculateAngle(Position, target));
				}
				CheckTarget(Level1.Creature1);
			}else{
				speed = Follow(startingPoint, Position, 0, maxSpeed);
				SetTarget(Level1.Creature1);
			}
			collision0(new Player[]{Level1.Player1});
			base.Update();
		}
		public override void Draw(SpriteBatch batch){
			base.Draw(batch);
			batch.DrawString(Font, ""+target, new Vector2(0,512), Color.White);
		}
	}
}
