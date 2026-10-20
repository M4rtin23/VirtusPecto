using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class MouseHandler{
		public static Vector2 Position{get => Mouse.GetState().Position.ToVector2();}
		private static bool checker;
		public static bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed);}

		public static void Click(Action action){
			if (IsClicking && !checker){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}
		public static void Click(RectangleF rectangle, Action action){
			if (IsClicking && !checker && rectangle.Contains(Position)){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}
	}
}