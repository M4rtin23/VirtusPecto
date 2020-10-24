using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class Nearest : TickBox{
		protected override bool state{get => ShowNearest; set => ShowNearest = value;}
		public Nearest(){
			name = "Show Nearest Enemy";
		}
	}
}
