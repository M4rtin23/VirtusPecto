using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public partial class Game1{
		public static bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && IsJoystick);}
		
		public static void SetWindowSize(Vector2 size){
			Width = (int)size.X;
			Height = (int)size.Y;
			graphics.ApplyChanges();
		}

		private void pause(){
			InputKeys.Press(5, () => {IsPaused = !IsPaused;}, ref checker);

			if (!IsPaused) {
				Pause = null;
			}
			if (IsPaused) {
				if (Pause == null) {
					Pause = new PauseMenu();
				}
				Pause?.Update();    
			}
		}
		public static void GoToLevel(int level){
			if(level != LevelNumber){
				PreviousLevel = LevelNumber;
				LevelNumber = level;
			}
		}
		public static void GoToPrevious(){
			GoToLevel(PreviousLevel);
		}
		public static (Vector2, int) GetClosest(GameBuilder.ObjectBuilder[] entities, Vector2 pos){
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
}
