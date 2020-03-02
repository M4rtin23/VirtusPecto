using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class DifficultyBox : OptionBox{
		public DifficultyBox(int x, int y){
			name = "Enemies";
			optionsNumber = 10;
			for(int i = 0; i < optionsNumber; i++){
				Options[i].X = (i + 1)*5;			
			}
		}
		protected override string drawOptions(int i){
			return ""+Options[i].X;
		}
	}
}
