using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class CardDescription : TickBox{
		protected override bool state{get => IsDescriptionOn; set => IsDescriptionOn = value;}
		public CardDescription(){
			name = "Show Description";
		}
	}
}
