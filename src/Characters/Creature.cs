using Microsoft.Xna.Framework;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class Creature : Entity{
		public Creature(CardContent content,Vector2 pos){
			enemy = Level1.Enemy1;
			SpriteIndex = content.Sprite;
			Position = pos;
			maxSpeed = content.Spd;
			dist = content.Dist;
			startingPoint = pos;
			SetTarget(enemy);
			color1 = Color.DeepSkyBlue;
			powerIndex = content.PowerIndex;
			health = content.HP;
			maxHealth = health;
		}
		public override void Update() {
			if(GlobalGameTime.TotalGameTime.Minutes - time > 1){
				SetTarget(enemy);
			}
			base.Update();
			entityCollision(Level1.Creature1);
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
