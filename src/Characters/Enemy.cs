using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Enemy : Entity{
		public Enemy(Vector2 pos){
			powerIndex = 2;
			SpriteIndex = Sprite0;
			Position = pos;
			maxSpeed = 3;
			startingPoint = pos;
			dist = 33+255*0;
			color1 = Color.Red;
		}
		public override void Update() {
			enemy = Level1.Creature1;
			SetTarget(enemy);
			base.Update();
			collision0(new Player[]{Level1.Player1});
			collision0(Level1.Enemy1);
		}
		public override void Draw(SpriteBatch batch){
			base.Draw(batch);
			batch.DrawString(Font, ""+target, new Vector2(0,512), Color.White);
		}
	}
}
