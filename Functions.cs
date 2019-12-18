using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public partial class Game1{
        public static Vector2 GetMatrix(){
            return matrixPosition;
        }
        public static int Width(){
            return graphics.PreferredBackBufferWidth;
        }
        public static int Height(){
            return graphics.PreferredBackBufferHeight;
        }
        public static bool IsFullScreen(){
            return graphics.IsFullScreen;
        }
        public static void SetWindowSize(Vector2 size){
            graphics.PreferredBackBufferWidth = (int)size.X;
            graphics.PreferredBackBufferHeight = (int)size.Y;
            graphics.ApplyChanges();
        }
        public static void Fullscreen(bool state){
            graphics.IsFullScreen = state;
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
        private void matrix(){
            if(LevelNumber == 1){
                Mat = Camera.Follow(Levels.Player1.Position);
            }
            matrixPosition = - new Vector2(Mat.M41, Mat.M42);
            Mouse1.SetMPosition(matrixPosition);
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
    }
}