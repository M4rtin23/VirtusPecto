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
		public static PlayButton Button1;
		public static SettingsButton Button2;
		public static Vector2 SpriteLogoPosition;
		private int exitAlpha;
		private RectangleF ExitRectangle{get => new RectangleF((Width / 4), Height / 1.85f, 128, 32);}

		bool checker;
		public Lobby(){
			Background = new BackGround(SpriteBackground);
			Button1 = new PlayButton(Width/4, (int)((float)Height/2.4f));
			Button2 = new SettingsButton();
			SpriteLogoPosition = new Vector2(Width/4f, 128);
		}
		public void Update() {
			Button1.Collision();
			Button2.Collision();
			if (ExitRectangle.Contains(Mouse1.Position)){
				exitAlpha = 64;
				if (IsClicking) {
					WannaExit = true;
				}
			}else {
				exitAlpha = 0;
			}
			Button1.SetPosition(Width/4, (float)Height/2.4f);
			
			SpriteLogoPosition = new Vector2(Width / 2f - 220, 128);
		}
		public void Draw(SpriteBatch batch) {
			Background.Draw(batch, new Vector2(Width/2, Height/2));
			batch.Draw(SpriteLogo, new Vector2(SpriteLogoPosition.X - 128, SpriteLogoPosition.Y), Color.White);
			batch.DrawString(FontBig, "Virtus Pecto", new Vector2(SpriteLogoPosition.X, SpriteLogoPosition.Y), Color.White);
			Button1.Draw(batch);

			Button2.Draw(Width/4, (float)Height/2.1f, batch);

			ExitRectangle.Draw(batch, new Color(exitAlpha, exitAlpha, exitAlpha, exitAlpha));

			batch.DrawString(FontNormal, "Exit", new Vector2(ExitRectangle.X, ExitRectangle.Y), Color.White);
		}
	}
}
