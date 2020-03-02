using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class AspectBox : OptionBox{
		public AspectBox(){
			optionsNumber = 6;
			name = "Aspect Ratio";
			Options[0] = new Vector2(16f, 9f);
			Options[1] = new Vector2(16f, 10f);
			Options[2] = new Vector2(21f, 9f);
			Options[3] = new Vector2(4f, 3f);
			Options[4] = new Vector2(5f, 4f);
			Options[5] = new Vector2(1f, 1f);
		}

		protected override string drawOptions(int i){
			return " "+ Options[i].X + ":" + Options[i].Y;
		}
		
	}
}