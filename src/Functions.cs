using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public partial class Game1{
		public static bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && Game1.Joystick != null);}
		
		public static void SetWindowSize(Vector2 size){
			Width = (int)size.X;
			Height = (int)size.Y;
			graphics.ApplyChanges();
		}
		public static bool IsPressing(int index){
			if(!IsJoystick){
				return Keyboard.GetState().IsKeyDown(TheKeys[index]);
			}else{
				return GamePad.GetState(PlayerIndex.One).IsButtonDown(TheButtons[index]);
			}
		}
		private void joystick(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				IsJoystick = true;
			}
			if(IsJoystick){
				if(Joystick == null){
					Joystick = new GameControl();
				}
			}else{
				Joystick = null;
			}
			Joystick?.Update();
		}
		private void pause(){
			if (IsPressing(5)){
				checker = true;
			}
			if (!IsPressing(5) && checker){
				IsPaused = !IsPaused;
				checker = false;
			}
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
				int enemyDistance = (int)CalculateDistance(entities[i].Position, pos);
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
