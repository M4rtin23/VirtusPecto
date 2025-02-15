using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;


namespace VirtusPecto.Desktop{	
	public class WindowBox : OptionBox{	
		public WindowBox():base("Window Size", 9, new Vector2[]{Vector2.One*1200,Vector2.One*1080,Vector2.One*1050,Vector2.One*1024,Vector2.One*900,Vector2.One*800,Vector2.One*768,Vector2.One*765,Vector2.One*720}){}
		protected override void action(int i){
			bool fullscreen = IsFullscreen;
			IsFullscreen = false;
			Width = (int)(Options[Option].Y * Settings.AspectRatio.X/Settings.AspectRatio.Y);
			Height = (int)Options[Option].Y;
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
