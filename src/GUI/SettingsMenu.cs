using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;

namespace VirtusPecto.Desktop{
	public class SettingsMenu: Screen{
		public OptionBox ResolutionBox;
		public TickBox SetFullscreen;
		public TickBox ShowNearest;
		public TickBox ShowDirection;
		public OptionBox SetAspectRatio;
		public TickBox SetJoystick;
		public TickBox ShowDescription;
		public TickBox ShowEnemyDir;

		private Button Back = new Button("Go Back", () => {if(Level1 != null) Game1.Screen = Level1; else Game1.Screen = StartMenu; Settings = null;});
		Vector2 aR{get => SetAspectRatio.Options[SetAspectRatio.Option]/SetAspectRatio.Options[SetAspectRatio.Option].Y;}

		public SettingsMenu(){
			ShowDescription = new TickBox("Show Description");
			ShowNearest = new TickBox("Mark Nearest Enemy");
			ShowDirection = new TickBox("Show Mouse Direction");
			SetJoystick = new TickBox("Joystick");
			SetAspectRatio = new OptionBox("Aspect Ratio", 6, ":",
				new Vector2[]{new Vector2(16f, 9f),new Vector2(16f, 10f),new Vector2(21f, 9f),new Vector2(4f, 3f),new Vector2(5f, 4f),new Vector2(1f, 1f)},
				() => {
					ResolutionBox.Options = new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720};
				}
			);
			SetFullscreen = new TickBox("Fullscreen");
			ResolutionBox = new OptionBox("Window Size", 9, " X ",
				new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720},
				() => {
					Width = (int)(ResolutionBox.Options[ResolutionBox.Option].Y * aR.X);
					Height = (int)ResolutionBox.Options[ResolutionBox.Option].Y;
				}
			);
			ResolutionBox.SetDefaultOption(" "+ Width + " X " + Height);
			ShowEnemyDir = new TickBox("Show Enemy Direction");
		}

		public override void Update(){
			bool temp = IsFullscreen;
			ShowDirection.Update(Width * 3/4 - 64, 2*Height / 3, ref Game1.ShowDirection);
			ShowNearest.Update(Width * 2/4 - 64, 2*Height / 3, ref Game1.ShowNearest);
			SetAspectRatio.Update(Width / 4 - 64,  Height / 3);
			ShowDescription.Update(Width * 2/4 - 64,  Height / 2, ref IsDescriptionOn);
			SetFullscreen.Update(Width * 3/4 - 64,  Height / 3, ref temp);
			SetJoystick.Update(Width * 3/4 - 64,  Height / 2,  ref IsJoystick);
			ResolutionBox.Update(Width * 2/4 - 64, Height / 3);
			ShowEnemyDir.Update(Width / 4 - 64, Height / 2, ref Enemy.ShowDirection);
			Back.Update(0, 0);
			IsFullscreen = temp;
		}
		public override void Draw(SpriteBatch batch){
			Back.Draw(batch);			
			ShowDirection.Draw(batch);
			ShowNearest.Draw(batch);
			ShowDescription.Draw(batch);
			SetAspectRatio.Draw(batch);
			ResolutionBox.Draw(batch);
			ShowEnemyDir.Draw(batch);
			SetFullscreen.Draw(batch);
			SetJoystick.Draw(batch);
		}
	}
}
