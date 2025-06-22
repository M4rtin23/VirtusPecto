using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;

namespace VirtusPecto.Desktop{
	public class SettingsMenu: Screen{
		Box[] setting = new Box[8];
		OptionBox aspectRatio, resolution;

		private Button Back = new Button("Go Back", () => {if(Level1 != null) Game1.Screen = Level1; else Game1.Screen = StartMenu; Settings = null;});
		Vector2 aR{get => aspectRatio.Options[aspectRatio.Option]/aspectRatio.Options[aspectRatio.Option].Y;}

		public SettingsMenu(){
			setting[4] = new TickBox("Show Description", IsDescriptionOn);
			setting[7] = new TickBox("Mark Nearest Enemy", ShowNearest);
			setting[6] = new TickBox("Show Mouse Direction", ShowDirection);
			setting[5] = new TickBox("Joystick",  IsJoystick);
			setting[0] = aspectRatio = new OptionBox("Aspect Ratio", 6, ":",
				new Vector2[]{new Vector2(16f, 9f),new Vector2(16f, 10f),new Vector2(21f, 9f),new Vector2(4f, 3f),new Vector2(5f, 4f),new Vector2(1f, 1f)},
				() => {
					resolution.Options = new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720};
				}
			);
			setting[2] = new TickBox("Fullscreen", IsFullscreen);
			setting[1] = resolution = new OptionBox("Window Size", 9, " X ",
				new Vector2[]{aR*1200,aR*1080,aR*1050,aR*1024,aR*900,aR*800,aR*768,aR*765,aR*720},
				() => {
					Width = (int)(resolution.Options[resolution.Option].Y * aR.X);
					Height = (int)resolution.Options[resolution.Option].Y;
				}
			);
			resolution.SetDefaultOption(" "+ Width + " X " + Height);
			setting[3] = new TickBox("Show Enemy Direction", Enemy.ShowDirection);
		}

		public override void Update(){
			for(int i = 0; i < setting.Length; i++){
				setting[i].Update(Width/4 * (i % 3 + 1) - 64, Height/6 * (i / 3 + 2));
			}
			Back.Update(0, 0);
			IsDescriptionOn = setting[4].State;
			ShowNearest = setting[7].State;
			ShowDirection = setting[6].State;
			IsJoystick = setting[5].State;
			IsFullscreen = setting[2].State;
			Enemy.ShowDirection = setting[3].State;
		}
		public override void Draw(SpriteBatch batch){
			Back.Draw(batch);
			for(int i = setting.Length; i > 0; i--){
				setting[i-1].Draw(batch);
			}
		}
	}
}
