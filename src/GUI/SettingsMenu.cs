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
		private Rectangle Back = new Rectangle(0, 0, SpriteTick.Width/2, SpriteTick.Height);
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
			ShowDirection.SetPosition(Width * 3/4 - 64, 2*Height / 3);
			ShowNearest.SetPosition(Width * 2/4 - 64, 2*Height / 3);
			SetAspectRatio.SetPosition(Width / 4 - 64,  Height / 3);
			ShowDescription.SetPosition(Width * 2/4 - 64,  Height / 2);
			SetFullscreen.SetPosition(Width * 3/4 - 64,  Height / 3);
			SetJoystick.SetPosition(Width * 3/4 - 64,  Height / 2);
			ResolutionBox.SetPosition(Width * 2/4 - 64, Height / 3);
			SetAspectRatio.Collision();
			ResolutionBox.Collision();
			if(Back.Contains(Mouse1.Position) && IsClicking){
				GoToPrevious();
				Settings = null;
			}
		}
		public void Draw(SpriteBatch batch){
			batch.Draw(SpriteTick, new Vector2(0, 0), Color.White);
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
