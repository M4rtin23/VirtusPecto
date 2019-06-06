using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameMaker.MakerObject;

namespace VirtusPecto.Desktop{    
	public class FireBall{
		private bool isDangerous;
		public Vector2 Position;
		public Rectangle GetCollision;
        private float imageIndex;
        private float hspeed, vspeed;
        private float rotation;
		//True = emited by the enemy && False = emited by de user
		public FireBall(bool emiter, Vector2 initialPosition, float hs, float vs){
			isDangerous = emiter;
			Position = initialPosition;
            vspeed = vs;
            hspeed = hs;
            rotation = (float)CalculateDirection(hspeed, vspeed);
    	}
		public void Update() {
            imageIndex+=0.25f;
            if (imageIndex > 3){
                imageIndex = 0;
            }
			GetCollision = new Rectangle((int)Position.X - 32,(int) Position.Y - 32, 96, 96);         
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
		public void Draw(SpriteBatch sprBt) {
            //DrawRectangle(spriteBatch, Sprite2, GetCollision, Color.White);
            sprBt.Draw(Sprite5, Position, new Rectangle(0, 128 * (int)imageIndex, 128, 128), Color.White, (180-rotation)/180*(float)Math.PI, new Vector2(64, 64), new Vector2(1, 1),/* effect*/SpriteEffects.None, 0);
		}
  	}
}
