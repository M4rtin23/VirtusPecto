using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Game1;

namespace VirtusPecto.Desktop{
	public class Fullscreen : TickBox{
		protected override bool state{get => IsFullscreen; set => IsFullscreen = value;}
		public Fullscreen(int x, int y){
			name = "Fullscreen";
		}
	}
}
