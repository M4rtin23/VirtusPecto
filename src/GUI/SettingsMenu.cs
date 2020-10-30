using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class SettingsMenu{
		public WindowBox ResolutionBox;
		public Fullscreen SetFullscreen;
		public Nearest ShowNearest;
		public Direction ShowDirection;
		public AspectBox SetAspectRatio;
		public Joystick SetJoystick;
		public CardDescription ShowDescription;
		private Button Back = new Button("Go Back", () => {GoToPrevious(); Settings = null;});
		public Vector2 AspectRatio{get => SetAspectRatio.Options[SetAspectRatio.Option];}
		public SettingsMenu(){
			ShowDescription = new CardDescription();
			ShowNearest = new Nearest();
			ShowDirection = new Direction();
			SetJoystick = new Joystick();
			SetAspectRatio = new AspectBox();
			SetFullscreen = new Fullscreen();
			ResolutionBox = new WindowBox();
		}

		public void Update(){
			ShowDirection.Update(Width * 3/4 - 64, 2*Height / 3);
			ShowNearest.Update(Width * 2/4 - 64, 2*Height / 3);
			SetAspectRatio.Update(Width / 4 - 64,  Height / 3);
			ShowDescription.Update(Width * 2/4 - 64,  Height / 2);
			SetFullscreen.Update(Width * 3/4 - 64,  Height / 3);
			SetJoystick.Update(Width * 3/4 - 64,  Height / 2);
			ResolutionBox.Update(Width * 2/4 - 64, Height / 3);
			Back.Update(0, 0);
		}
		public void Draw(SpriteBatch batch){
			Back.Draw(batch);			
			ShowDirection.Draw(batch);
			ShowNearest.Draw(batch);
			ShowDescription.Draw(batch);
			SetAspectRatio.Draw(batch);
			ResolutionBox.Draw(batch);
			SetFullscreen.Draw(batch);
			SetJoystick.Draw(batch);
		}
	}
}
