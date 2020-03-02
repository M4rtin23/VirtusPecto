using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class Entity : GameBuilder.ObjectBuilder{
		protected Vector2 target, startingPoint;
		protected int health = 100;
		protected float dist;
		protected int targetDefined = -1;
		protected bool isAttacking;
		protected int time;

		public override void Update() {
			Hitbox = new RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			animationImage(4);
			lookAtTarget();
			if(speed == Vector2.Zero){
				imageIndex = 2;
			}else{
				animationSpeed = 0.125f;        
			}
			base.Update();
		}
		public override void Draw(SpriteBatch batch) {
			//DrawRectangle(batch, Hitbox, Color.White);
			//Hitbox.Draw(batch);
			center(4);
			stripSprite(4);
			base.Draw(batch);
			if(health < 100){
				batch.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(64, 64, 64, 150), 0, new Vector2(0, 0), new Vector2(1, 1/4f), SpriteEffects.None, 0.1f);
				batch.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(255, 0, 0, 115), 0, new Vector2(0, 0), new Vector2((float)health/100, 1/4f), SpriteEffects.None, 0);
			}
		}
		public void SetTarget(Entity[] entities){
			(Vector2, int) test = GetClosest(entities, Position);
			if (test.Item2 != -1){
				time = GT.TotalGameTime.Minutes;
				targetDefined = test.Item2;
				target = entities[targetDefined].Position;
				isAttacking = true;
			}else{
				isAttacking = false;
			}
		}
		protected void lookAtTarget(){
			if (CurrentTarget() > Position.X){
				effect = SpriteEffects.None;
			}else{
				effect = SpriteEffects.FlipHorizontally;
			}
		}
		public void CheckTarget(Entity[] entities){
			if (targetDefined != -1){
				if (entities[targetDefined] == null){
					targetDefined = -1;
				}else{
					target = entities[targetDefined].Position;
				}
			}else{
				SetTarget(entities);
			}
		}
		public float CurrentTarget(){
			float tr = 0;
			if(!isAttacking){
				tr = startingPoint.X;
			}else{
				tr = target.X;
			}
			return tr;
		}
		protected void followTarget(){
			speed = Builder.Follow(target, Position, 64 + dist, maxSpeed);
		}  
		public void AddHealth(int number){
			health += number;
		}
		public int GetHealth(){
			return health;
		}
		public Vector2 GetStartingPoint(){
			return startingPoint;
		}
	}
}
