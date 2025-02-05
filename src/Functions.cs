using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public partial class Game1{
		public static (Vector2, int) GetClosest(GameBuilder.InGame.ObjectBuilder[] entities, Vector2 pos){
			float shortestDistance = -1;
			int targetDefiner = -1;
			for (int i = 0; i < entities.Length; i++) {
				//Sees if the object indexed exists.
				if (entities[i] == null) {
					continue;
				}
				//Calculates a distance.
				int enemyDistance = (int)Motion.Distance(entities[i].Position, pos);
				//Compares  
				if (shortestDistance == -1) {
					shortestDistance = enemyDistance;               
				}
				//Defines the closest.
				if (enemyDistance <= shortestDistance){
					shortestDistance = enemyDistance;
					targetDefiner = i;
				}
			}
			if (targetDefiner != -1){
				return (entities[targetDefiner].Position, targetDefiner);
			}else{
				return (new Vector2((float)double.NaN, (float)double.NaN), -1);
			}
		}
	}
	public abstract class Screen{
		public abstract void Update();
		public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
	}
}
