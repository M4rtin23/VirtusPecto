using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class Lobby : Screen{
		public static Button Button1;
		public static Button Button2;
		public static Button Button3;

		public Lobby(){
			Button1 = new PlayButton();
			Button2 = new Button("Settings", () => {Settings = new SettingsMenu();
					Pause = null;
					Game1.Screen = Settings;
				});
			Button3 = new Button("Exit", () => {WannaExit = true;});
		}
		public override void Update() {
			Button1.Update(Width/4, (float)Height/2.4f);
			Button2.Update(Width/4, (float)Height/2.1f);
			Button3.Update((Width / 4), Height / 1.85f);
		}
		public override void Draw(SpriteBatch batch) {
//			batch.Draw(SpriteCard, new Vector2(Width/2, Height/4), null, new Color(79,79,79), 0, new Vector2(SpriteCard.Width, SpriteCard.Height/4)/2, 4, SpriteEffects.None, 1);
			batch.Draw(SpriteLogo, new Vector2(Width/2 - 480, Height/4 - 64*2), null, new Color(79,79,79), 0, Vector2.Zero, 2, SpriteEffects.None, 1);
			batch.Draw(SpriteTitle, new Vector2(Width/2+64, Height/4), null,Color.White, 0, new Vector2(SpriteTitle.Width, SpriteTitle.Height)/2, 8, SpriteEffects.None, 1);
//			batch.DrawString(FontBig, "Virtus Pecto", new Vector2(Width / 2f - 220, Height/4 - 64), Color.White);

			Button1.Draw(batch);
			Button2.Draw(batch);
			Button3.Draw(batch);
		}
	}
}
