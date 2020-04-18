using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Enemy : Entity{
		bool o = false;
		GameBuilder.RectangleF attacking{get => new GameBuilder.RectangleF(64*GameBuilder.Motion.VectorSpeed(1, MathHelper.ToRadians((float)CalculateAngle(Position, target)))+Position - Vector2.One*32, 64);}
		public Enemy(Vector2 pos){
			SpriteIndex = Sprite0;
			Position = pos;
			maxSpeed = 3;
			startingPoint = pos;
			dist = 33;
			color1 = Color.Red;
		}
		public override void Update() {
			enemy = Level1.Creature1;
			SetTarget(enemy);
			base.Update();
			collision0(new Player[]{Level1.Player1});
			collision0(Level1.Enemy1);
			if(o){
				if(attacking.Contains(target)){
					Level1.Creature1[targetDefined].AddHealth(-10);
				}
			}
			o = false;
		}
		public override void Draw(SpriteBatch batch){
			base.Draw(batch);
			batch.DrawString(Font, ""+target, new Vector2(0,512), Color.White);
		}
		protected override void attack(float angle){
			o = true;
		}
	}
}
