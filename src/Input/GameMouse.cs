using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public Vector2 Position{get => Mouse.GetState().Position.ToVector2();}
        private Vector2 speed;
		public Vector2 MPosition{get => Position + MatrixPosition;}
		private bool checker;
		public bool IsInside{get => (Position.Y < Game1.Height-288);}
		public static bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && IsJoystick);}

		public void Update(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				IsJoystick = true;
			}
			if(IsJoystick){
				//This is used for a fixed position of the cursor, just to avoid the cursor moving with the mouse. 
				//Mouse.SetPosition(position.X, position.Y);
				//position += speed;

				//This is for allowing the movement of the cursor with the mouse.
				Mouse.SetPosition((int)Mouse.GetState().X + (int)speed.X,(int)Mouse.GetState().Y + (int)speed.Y);
				speed.X = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * (Game1.Height/70f);
				speed.Y = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * (-Game1.Height/70f);
		
			}

			/*if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Level1.Player1.Position.X,(int) Level1.Player1.Position.Y);
			}*/
		}
		public void Click(Action action){
			if (IsClicking && !checker){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}
		public void Click(RectangleF rectangle, Action action){
			if (IsClicking && !checker && rectangle.Contains(Position)){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}

		public static void Click(Action action, ref bool check){
			if (IsClicking && !check){
				action();
				check = true;
			}
			if (!IsClicking){
				check = false;
			}
		}
	}
}