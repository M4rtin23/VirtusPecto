using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public static Vector2 Position{get => Mouse.GetState().Position.ToVector2();}
		public static Vector2 MPosition{get => Position + MatrixPosition;}
		private bool checker;
		public static bool IsInside{get => (Position.Y < Game1.Height-288);}
		public static bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && IsJoystick);}

		public void Update(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				IsJoystick = true;
			}
			if(IsJoystick){
				Mouse.SetPosition((int)Mouse.GetState().X + (int)(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * (Game1.Height/70f)),(int)Mouse.GetState().Y + (int)(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * (-Game1.Height/70f)));
			}
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