using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Game1;

namespace VirtusPecto.Desktop{
	public class WindowBox : OptionBox{
		public WindowBox(){
			name = "Window Size";
			Options[0].Y = 1200;
			Options[1].Y = 1080;
			Options[2].Y = 1050;
			Options[3].Y = 1024;
			Options[4].Y = 900;
			Options[5].Y = 800;
			Options[6].Y = 768;
			Options[7].Y = 720;
		}
		protected override int n(){
			return 8;
		}
		protected override void action(int i){
			SetWindowSize(Options[i]);
		}
		protected override void update(){
			for (int i = 0; i < OptionsNumber; i++){
				Options[i].X = (float)Math.Ceiling(Settings.AspectRatio.X / Settings.AspectRatio.Y * Options[i].Y);
			}
		}
		protected override string drawOptions(int i){
			string a = " "+Convert.ToString(Options[i].X) + " X " + Convert.ToString(Options[i].Y);
			return a;
		}
		protected override string currentOption(){
			string a = " "+Convert.ToString(Width) + " X " + Convert.ToString(Height);
			return a;
		}

	}
}
