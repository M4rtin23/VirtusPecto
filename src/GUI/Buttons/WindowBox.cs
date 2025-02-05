using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;

namespace VirtusPecto.Desktop{
	public class WindowBox : OptionBox{
		Vector2 realOption{get => new Vector2(Options[Option].Y * Settings.AspectRatio.X/Settings.AspectRatio.Y, Options[Option].Y);}
		public WindowBox(){
			optionsNumber = 9;
			name = "Window Size";
			Options[0].Y = 1200;
			Options[1].Y = 1080;
			Options[2].Y = 1050;
			Options[3].Y = 1024;
			Options[4].Y = 900;
			Options[5].Y = 800;
			Options[6].Y = 768;
			Options[7].Y = 765;
			Options[8].Y = 720;
		}
		protected override void action(int i){
			bool fullscreen = IsFullscreen;
			IsFullscreen = false;
			Width = (int)realOption.X;
			Height = (int)realOption.Y;
			IsFullscreen = fullscreen;
		}
		protected override string drawOptions(int i){
			return " "+ (int)(Options[i].Y * Settings.AspectRatio.X/Settings.AspectRatio.Y) + " X " + Options[i].Y;
		}
		protected override string currentOption(){
			return " "+ Width + " X " + Height;	
		}

	}
}
