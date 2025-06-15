using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class Enemy : Agent{
		public static bool ShowDirection = false;
		public Enemy(Vector2 pos){
			powerIndex = 2;
			SpriteIndex = SpriteEnemy;
			Position = pos;
			maxSpeed = 3;
			startingPoint = pos;
			dist = 33+255*0;
			color1 = Color.Red;
			health = 100;
			maxHealth = 100;
		}
		public override void Update() {
			enemy = Level1.Creature1;
			Level1.CreateObject(Level1.Player1, ref enemy);
			SetTarget(enemy);
			base.Update();
			entityCollision(new Player[]{Level1.Player1});
			entityCollision(Level1.Enemy1);
		}
		public override void Draw(SpriteBatch batch){
			float r = new GameBuilder.Motion(speed).Radians;
			Vector2 v = new Vector2(-(float)System.Math.Cos(r), (float)System.Math.Sin(r));
			if(ShowDirection){
				GameBuilder.Shapes.Line.Draw(batch, Position + v*32, Position + v*64, 6, Color.Red);
			}
			base.Draw(batch);
		}
	}
}
