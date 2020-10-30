using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class InputKeys{
		public static Keys[] TheKeys = {Keys.W, Keys.A, Keys.S, Keys.D, Keys.Space, Keys.Escape, Keys.D1, Keys.D2, Keys.D3};
		public static Buttons[] TheButtons = {Buttons.DPadUp, Buttons.DPadLeft, Buttons.DPadDown, Buttons.DPadRight, Buttons.RightShoulder, Buttons.Start, Buttons.X, Buttons.Y, Buttons.B};

		public static void Press(Keys key, Action action, ref bool check){
			if (Keyboard.GetState().IsKeyDown(key) && !check){
				action();
				check = true;
			}
			if (!Keyboard.GetState().IsKeyDown(key)){
				check = false;
			}
		}
		public static void Press(int index, Action action, ref bool check){
			if (IsPressing(index) && !check){
				action();
				check = true;
			}
			if (!IsPressing(index)){
				check = false;
			}
		}

		public static bool IsPressing(int index){
			if(!IsJoystick){
				return Keyboard.GetState().IsKeyDown(TheKeys[index]);
			}else{
				return GamePad.GetState(PlayerIndex.One).IsButtonDown(TheButtons[index]);
			}
		}

	}
}