using Microsoft.Xna.Framework;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Creature : Entity{
		public Creature(CardContent content,Vector2 pos){
			SpriteIndex = content.Sprite;
            Position = pos;
			maxSpeed = content.Spd;
			dist = content.Dist;
            startingPoint = pos;
			SetTarget(Level1.Enemy1);
		}
		public override void Update() {
			if(GT.TotalGameTime.Minutes - time > 1){
				SetTarget(Level1.Enemy1);
			}
			if(isAttacking){
				followTarget();
				if(speed == Vector2.Zero && dist > 0 && dist > CalculateDistance(Position, target)/2 && (GT.TotalGameTime.Milliseconds % 1000 == 0)){
					Level1.CreateFireball(false, Position, (float)CalculateAngle(Position, target));
				}
				CheckTarget(Level1.Enemy1);
			}else{
				speed = Follow(startingPoint, Position, 0, maxSpeed);
				SetTarget(Level1.Enemy1);
			}
			base.Update();
		}
		public void Follow2(Vector2 target, Vector2 Position, float hitboxSize){
			if (target.X - hitboxSize/2 > Position.X){
				speed.X = maxSpeed;
			}
			else
			if (target.X + hitboxSize/2 < Position.X){
				speed.X = -maxSpeed;
			}else{
				speed.X = 0;
			}
			if (target.Y - hitboxSize/2 > Position.Y){
				speed.Y = maxSpeed;
			}
			else
			if (target.Y + hitboxSize/2 < Position.Y){
				speed.Y = -maxSpeed;
			}else{
				speed.Y = 0;
			}
		}
	}
}
