using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.Shapes;
using GameBuilder.InGame;

namespace VirtusPecto.Desktop{
	public abstract class Agent : Entity{
		protected Vector2 target, startingPoint;
		protected float maxHealth = 100;
		protected float dist;
		protected int targetDefined = -1;
		protected int time;
		protected Color color1 = Color.Green;
		protected Entity[] enemy;
		public override void Update() {
			if(health <= 0){
				Level1.Destroy(Level1.Enemy1);
				Level1.Destroy(Level1.Creature1);
			}
			Hitbox = new RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			lookAtTarget();
			if(speed == Vector2.Zero){
				imageIndex = 2;
			}else{
				animationSpeed = 0.125f;
			}
			base.Update();
			speed = Motion.Follow(Position, target, 32 + dist, maxSpeed);
			if(speed == Vector2.Zero && (GlobalGameTime.TotalGameTime.Milliseconds % 1000 == 0) && targetDefined != -1){
				Power.GetPower(powerIndex).UsePower(Position, target, enemy);
			}
			SetTarget(enemy);
		}
		public override void Draw(SpriteBatch batch) {
			base.Draw(batch);
			if(health < maxHealth){
				new RectangleF(Position - new Vector2(64, 80), new Vector2(128, 8), new Color(64, 64, 64, 150)).Draw(batch, 0.1f);
				new RectangleF(Position - new Vector2(64, 80), new Vector2(128*(float)health/maxHealth, 8), new Color(color1, 115)).Draw(batch);
			}
		}
		public void SetTarget(ObjectBuilder[] entities){
			if(targetDefined == -1){
				targetDefined = GetClosest(entities, Position);
			}else{
				if(entities[targetDefined] == null){
					targetDefined = -1;
					target = startingPoint;
				}else{
					target = entities[targetDefined].Position;
				}
			}
		}
		protected void lookAtTarget(){
			if (target.X > Position.X){
				effect = SpriteEffects.None;
			}else{
				effect = SpriteEffects.FlipHorizontally;
			}
		}
	}
}
