using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class Joystick : TickBox{
		protected override bool state{get => IsJoystick; set {if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){IsJoystick = true;}}}
		public Joystick(){
			name = "Joystick";
		}
	}
}