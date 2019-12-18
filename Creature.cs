using Microsoft.Xna.Framework;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Creature : Entity{
		public Creature(CardContent content,Vector2 pos){
			Hitbox = new Rectangle((int)pos.X,(int) pos.Y,128,128);
			SpriteIndex = content.Sprite;
			maxSpeed = content.Spd;
			dist = content.Dist;
			Position = pos;
            startingPoint = pos;
			SetTarget(Levels.Enemy1);
		}
		public override void Update() {
			if(time - GT.TotalGameTime.Minutes > 4){
				SetTarget(Levels.Enemy1);
			}
			Hitbox = new Rectangle((int) Position.X - 64+32, (int) Position.Y - 64, 128-32, 128);
			lookAtTarget();
			//Behaviors.
			if(!followPlayer){
				followTarget();
				if(speed == Vector2.Zero && dist > 0 && dist > CalculateDistance(Position, target)/2 && (GT.TotalGameTime.Milliseconds % 1000 == 0)){
					Levels.CreateFireBall(false, Position, (float)CalculateAngle(Position, target), 0);
				}
				CheckTarget(Levels.Enemy1);
			}else{
				speed = Follow(startingPoint, Position, 0, maxSpeed);
				SetTarget(Levels.Enemy1);
			}
            ////////////////////////////////////////////////////////////
			if(speed == Vector2.Zero){
				imageIndex = 2;
			}else{
				animationSpeed = 0.125f;                
			}
			animationImage(4);
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
