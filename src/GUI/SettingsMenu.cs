using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class SettingsMenu{
		public WindowBox ResolutionBox;
		public TickBox SetFullscreen;
		public TickBox ShowNearest;
		public TickBox ShowDirection;
		public AspectBox SetAspectRatio;
		public TickBox SetJoystick;
		public TickBox ShowDescription;
		private Button Back = new Button("Go Back", () => {GoToPrevious(); Settings = null;});
		public Vector2 AspectRatio{get => SetAspectRatio.Options[SetAspectRatio.Option];}

		public SettingsMenu(){
			ShowDescription = new TickBox("Show Description");
			ShowNearest = new TickBox("Mark Nearest Enemy");
			ShowDirection = new TickBox("Show Mouse Direction");
			SetJoystick = new TickBox("Joystick");
			SetAspectRatio = new AspectBox();
			SetFullscreen = new TickBox("Fullscreen");
			ResolutionBox = new WindowBox();
		}

		public void Update(){
			bool temp = IsFullscreen;
			ShowDirection.Update(Width * 3/4 - 64, 2*Height / 3, ref Game1.ShowDirection);
			ShowNearest.Update(Width * 2/4 - 64, 2*Height / 3, ref Game1.ShowNearest);
			SetAspectRatio.Update(Width / 4 - 64,  Height / 3);
			ShowDescription.Update(Width * 2/4 - 64,  Height / 2, ref IsDescriptionOn);
			SetFullscreen.Update(Width * 3/4 - 64,  Height / 3, ref temp);
			SetJoystick.Update(Width * 3/4 - 64,  Height / 2,  ref IsJoystick);
			ResolutionBox.Update(Width * 2/4 - 64, Height / 3);
			Back.Update(0, 0);
			IsFullscreen = temp;
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
