using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class GameMouse : MouseHandler{
		public static Vector2 MPosition{get => Position + MatrixPosition;}
		public static bool IsInside{get => (Position.Y < Game1.Height-288);}
		public static new bool IsClicking {get => (Mouse.GetState().LeftButton == ButtonState.Pressed) || (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && IsJoystick);}

		public void Update(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				IsJoystick = true;
			}
			if(IsJoystick){
				Mouse.SetPosition((int)Mouse.GetState().X + (int)(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * (Game1.Height/70f)),(int)Mouse.GetState().Y + (int)(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * (-Game1.Height/70f)));
			}
		}
	}
}