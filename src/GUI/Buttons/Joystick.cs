using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class Joystick : TickBox{
		public Joystick(float x, float y){
			name = "Joystick";
			state = IsJoystick;
		}
		protected override void update(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				state = true;
			}
			IsJoystick = state;
		}
	}
}