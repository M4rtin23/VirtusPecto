using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class PauseMenu{
		bool checker = true;
		private Button resume = new Button("Continue", () => {Pause = null;});
		private Button exit = new Button("Exit", () => {Environment.Exit(0);});
		private Button mainMenu = new Button("Main Menu", () => {Level1 = null;
			Pause = null;
			StartMenu = new Lobby();
			Game1.Screen = StartMenu;
		});
		public Button settings = new Button("Settings", () => {Settings = new SettingsMenu();
			Game1.Screen = Settings;
		});


		public void Update() {
			settings.Update((Width/2)-48, Height/2);
			resume.Update((Width / 2) - 48, (Height / 2) - 48*2);
			mainMenu.Update((Width / 2) - 48, (Height / 2) - 48);
			exit.Update((Width / 2) - 48, (Height / 2) + 48);
			InputKeys.Press(5, () => {Pause = null;}, ref checker);
		}
		public void Draw(SpriteBatch batch) {
			batch.Draw(SpriteCard, new Vector2((Width / 2), Height / 2), null, new Color(0,0,0,128), 0, new Vector2(128, 160), new Vector2(1, 1), SpriteEffects.None, 0);

			resume.Draw(batch);
			settings.Draw(batch);
			mainMenu.Draw(batch);
			exit.Draw(batch);

		}
	}
}
