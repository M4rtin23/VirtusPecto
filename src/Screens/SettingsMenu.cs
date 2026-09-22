using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;

namespace VirtusPecto.Desktop{
	public class SettingsMenu: SettingsScreen{
		OptionBox aspectRatio, resolution;
		bool check;
		private Button Back = new Button("Go Back", () => {if(Level1 != null) Game1.Screen = Level1; else Game1.Screen = StartMenu; Settings = null;});
		Vector2 aR{get => aspectRatio.Options[aspectRatio.Option]/aspectRatio.Options[aspectRatio.Option].Y;}

		public SettingsMenu():base(new UIElement[8], 3){
			settings[4] = new TickBox("Show Description", IsDescriptionOn);
			settings[7] = new TickBox("Mark Nearest Enemy", ShowNearest);
			settings[6] = new TickBox("Show Mouse Direction", ShowDirection);
			settings[5] = new TickBox("Joystick",  IsJoystick);
			settings[0] = aspectRatio = new OptionBox("Aspect Ratio", 6, ":",
			new Vector2[]{new Vector2(16f, 9f),new Vector2(16f, 10f),new Vector2(21f, 9f),new Vector2(4f, 3f),new Vector2(5f, 4f),new Vector2(1f, 1f)},
				() => {
					resolution.Options = new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720};
				}
			);
			settings[2] = new TickBox("Fullscreen", IsFullscreen);
			settings[1] = resolution = new OptionBox("Window Size", 9, " X ",
				new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720},
				() => {
					Width = (int)(resolution.Options[resolution.Option].Y * aR.X);
					Height = (int)resolution.Options[resolution.Option].Y;
				}
			);
			resolution.SetDefaultOption(" "+ Width + " X " + Height);
			settings[3] = new TickBox("Show Enemy Direction", Agent.ShowDirection);
		}

		public override void Update(){
			base.Update();
			Back.Update(0, 0);
			InputKeys.Press(5, Back.Action, ref check);
			IsDescriptionOn = settings[4].State;
			ShowNearest = settings[7].State;
			ShowDirection = settings[6].State;
			IsJoystick = settings[5].State;
			IsFullscreen = settings[2].State;
			Agent.ShowDirection = settings[3].State;
		}
		public override void Draw(SpriteBatch batch){
			Back.Draw(batch);
			base.Draw(batch);
		}
	}
}
