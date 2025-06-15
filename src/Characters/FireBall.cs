using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Fireball : GameBuilder.InGame.ObjectBuilder, INullable{
		Entity[] entities;
		bool isAlive = true;
		public Fireball(Entity[] entities, Vector2 initialPosition, Vector2 speed){
			SpriteIndex = SpriteFireball;
			this.entities = entities;
			Position = initialPosition;
			this.speed = speed;
			rot = MathHelper.Pi - (float)Motion.Direction(speed);
		}
		public override void Update() {
			animationSpeed = 0.25f;
			animationImage(3);
			Hitbox = new RectangleF((int)Position.X - 32,(int) Position.Y - 32, 96, 96);
			for (int i = 0; i < entities.Length; i++) {
				if (entities[i] != null && entities[i].Hitbox.Intersects(Hitbox)){
					isAlive = false;
					Level1.Destroy(Level1.Fireballs);
					entities[i].AddHealth(-10);
				}
			}
			base.Update();
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
