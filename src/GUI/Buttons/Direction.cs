using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class Direction : TickBox{
		protected override bool state{get => ShowDirection; set => ShowDirection = value;}
		public Direction(){
			name = "Show Mouse Direction";
		}
	}
}
