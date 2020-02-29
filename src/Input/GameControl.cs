using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class GameControl{
		private Vector2 position, speed;

		public GameControl(){
			position = new Vector2(500,500);
		}
		public void Update(){
			
			//This is used for a fixed position of the cursor, just to avoid the cursor moving with the mouse. 
			//Mouse.SetPosition(position.X, position.Y);
			//position += speed;

			//This is for allowing the movement of the cursor with the mouse.
			Mouse.SetPosition((int)Mouse.GetState().X + (int)speed.X,(int)Mouse.GetState().Y + (int)speed.Y);
	
			speed.X = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * (8);
			speed.Y = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * (-8);
		}
	}
}
