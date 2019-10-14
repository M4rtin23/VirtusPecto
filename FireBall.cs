using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{    
	public class FireBall : GameBuilder.ObjectBuilder{
		private bool isDangerous;
		//True = emited by the enemy && False = emited by de user
		public FireBall(bool emiter, Vector2 initialPosition, Vector2 speed){
			SpriteIndex = Sprite5;
            isDangerous = emiter;
			Position = initialPosition;
            this.speed = speed;
            rot = MathHelper.ToRadians(180 - (float)CalculateDirection(speed.X, speed.Y));
    	}
		public override void Update() {
            animationSpeed = 0.25f;
            animationImage(3);
			Hitbox = new Rectangle((int)Position.X - 32,(int) Position.Y - 32, 96, 96);         
			if (isDangerous) {
				PlayerCollision();
			}else{
				EnemyCollision();
			}
            base.Update();
		}
		public void EnemyCollision() {
			for (int i = 0; i < Levels.Enemy1.Length; i++) {
				if (Levels.Enemy1[i] != null){
					if (Hitbox.Intersects(Levels.Enemy1[i].Hitbox)){
						Levels.Enemy1[i] = null;
					}
				}
			}
		}
		public void PlayerCollision() {
			if (Hitbox.Intersects(Levels.Player1.Hitbox)) {
				Levels.Player1.Health -= 10;
			}
		}
		public override void Draw(SpriteBatch sprBt) {
            center(4);
            stripToSprite(4);
            base.Draw(sprBt);
        }
  	}
}
