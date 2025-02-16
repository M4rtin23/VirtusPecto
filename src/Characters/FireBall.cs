using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Fireball : GameBuilder.InGame.ObjectBuilder{
		private bool isDangerous;
		private bool isAlive = true;
		//True = emited by the enemy && False = emited by de user
		public Fireball(bool emiter, Vector2 initialPosition, Vector2 speed){
			SpriteIndex = SpriteFireball;
			isDangerous = emiter;
			Position = initialPosition;
			this.speed = speed;
			rot = MathHelper.Pi - (float)Motion.Direction(speed);
		}
		public override void Update() {
			animationSpeed = 0.25f;
			animationImage(3);
			Hitbox = new RectangleF((int)Position.X - 32,(int) Position.Y - 32, 96, 96);
			if (isDangerous) {
				PlayerCollision();
				CreatureCollision();
			}else{
				EnemyCollision();
			}
			base.Update();
		}
		public void EnemyCollision() {
			for (int i = 0; i < Level1.Enemy1.Length; i++) {
				if (isAlive && Level1.Enemy1[i] != null && Level1.Enemy1[i].Hitbox.Intersects(Hitbox)){
					isAlive = false;
					Level1.DestroyFireball();
					Level1.Enemy1[i]?.AddHealth(-10);
				}
			}
		}
		public void CreatureCollision() {
			for (int i = 0; i < Level1.Creature1.Length; i++) {
				if (isAlive && Level1.Creature1[i] != null && Level1.Creature1[i].Hitbox.Intersects(Hitbox)){
					isAlive = false;
					Level1.DestroyFireball();
					Level1.Creature1[i]?.AddHealth(-10);
				}
			}
		}

		public void PlayerCollision() {
			if (isAlive && Hitbox.Intersects(Level1.Player1.Hitbox)) {
				isAlive = false;
				Level1.DestroyFireball();
				Level1.Player1.AddHealth(-10);
			}
		}
		public override void Draw(SpriteBatch batch) {
			center(4);
			stripSprite(4);
			base.Draw(batch);
		}
		public bool GetState(){
			return isAlive;
		}
  	}
}
