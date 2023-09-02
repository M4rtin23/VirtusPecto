using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.Shapes;
using GameBuilder.InGame;

namespace VirtusPecto.Desktop{
	public abstract class Entity : Characters{
		protected Vector2 target, startingPoint;
		protected float maxHealth = 100;
		protected float dist;
		protected int targetDefined = -1;
		protected bool isAttacking;
		protected int time;
		protected Color color1 = Color.Green;
		protected Characters[] enemy;
		public override void Update() {
			if(health <= 0){
				Level1.DestroyEntities();
			}
			Hitbox = new RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			animationImage(4);
			lookAtTarget();
			if(speed == Vector2.Zero){
				imageIndex = 2;
			}else{
				animationSpeed = 0.125f;
			}
			base.Update();
			if(isAttacking){
				followTarget();
				if(speed == Vector2.Zero && (GT.TotalGameTime.Milliseconds % 1000 == 0)){
					attack((float)Motion.Angle(Position, target));
				}
				CheckTarget(enemy);
			}else{
				speed = Motion.Follow(startingPoint, Position, 32, maxSpeed);
				SetTarget(enemy);
			}
		}
		public override void Draw(SpriteBatch batch) {
			center(4);
			stripSprite(4);
			base.Draw(batch);
			if(health < maxHealth){
				new RectangleF(Position - new Vector2(64, 80), new Vector2(128, 8), new Color(64, 64, 64, 150)).Draw(batch, 0.1f);
				new RectangleF(Position - new Vector2(64, 80), new Vector2(128*(float)health/maxHealth, 8), new Color(color1, 115)).Draw(batch);
			}
		}
		public void SetTarget(ObjectBuilder[] entities){
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
		public void CheckTarget(ObjectBuilder[] entities){
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
			speed = Motion.Follow(Position, target, 32 + dist, maxSpeed);
		}  
		
		public Vector2 GetStartingPoint(){
			return startingPoint;
		}
		protected virtual void attack(float angle){
			switch(powerIndex){
				case 1:
				try{
					enemy?[targetDefined].AddHealth(-50);
					Level1.CreateParticle(target, 0.4f, 0);
				}catch{}
					break;
				case 0:
					Level1.CreateFireball((color1 == Color.Red), Position,(float)angle);
					break;
				case 2:
					Vector2 pos = 32*Motion.VectorSpeed(1, (float)Motion.Angle(Position, target))+Position - Vector2.One*32;
					if(new GameBuilder.Shapes.RectangleF(pos, 64).Contains(target)){
						Level1.CreateParticle(pos, 0.5f, 1);
						enemy?[targetDefined].AddHealth(-10);
					}
					break;
			}
		}
	}
}
