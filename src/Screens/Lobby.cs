using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class Lobby{
		public BackGround Background;
		public static Button Button1;
		public static Button Button2;
		public static Button Button3;
		public static Vector2 SpriteLogoPosition;

		public Lobby(){
			Background = new BackGround(SpriteBackground);
			Button1 = new PlayButton();
			Button2 = new Button("Settings", () => {Settings = new SettingsMenu();
					IsPaused = false;
					GoToLevel(2);
				});
			Button3 = new Button("Exit", () => {WannaExit = true;});
			SpriteLogoPosition = new Vector2(Width/4f, 128);
		}
		public void Update() {
			Button1.Update(Width/4, (float)Height/2.4f);
			Button2.Update(Width/4, (float)Height/2.1f);
			Button3.Update((Width / 4), Height / 1.85f);
			SpriteLogoPosition = new Vector2(Width / 2f - 220, 128);
		}
		public void Draw(SpriteBatch batch) {
			Background.Draw(batch, new Vector2(Width/2, Height/2));
			batch.Draw(SpriteLogo, new Vector2(SpriteLogoPosition.X - 128, SpriteLogoPosition.Y), Color.White);
			batch.DrawString(FontBig, "Virtus Pecto", new Vector2(SpriteLogoPosition.X, SpriteLogoPosition.Y), Color.White);
			Button1.Draw(batch);
			Button2.Draw(batch);
			Button3.Draw(batch);
		}
	}
}
