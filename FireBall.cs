using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{    
	public class FireBall{
		private bool isDangerous;
		public Vector2 Position;
		public Rectangle GetCollision;
        private float hspeed, vspeed; 
		//True = emited by the enemy && False = emited by de user
		public FireBall(bool emiter, Vector2 initialPosition, float hs, float vs){
			isDangerous = emiter;
			Position = initialPosition;
            vspeed = vs;
            hspeed = hs;
    	}
		public void Update() {
			GetCollision = new Rectangle((int)Position.X,(int) Position.Y, 128, 128);         
			Position.X += hspeed;
            Position.Y += vspeed;
			if (isDangerous) {
				PlayerCollision();
			}else{
				EnemyCollision();
			}
		}
		public void EnemyCollision() {
			for (int i = 0; i < Levels.Enemy1.Length; i++) {
				if (Levels.Enemy1[i] != null){
					if (GetCollision.Intersects(Levels.Enemy1[i].GetCollision)){
						Levels.Enemy1[i] = null;
					}
				}
			}
		}
		public void PlayerCollision() {
			if (GetCollision.Intersects(Levels.Player1.GetCollision)) {
				Levels.Player1.Health -= 10;
			}
		}
		public void Draw() {
            spriteBatch.Draw(Sprite0[0], Position, new Rectangle(0, 0, 128, 128), Color.Red, 0, new Vector2(64, 64), new Vector2(1, 1),/* effect*/SpriteEffects.None, 1f/Position.Y);
		}
  	}
}
