using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;
using System.Linq;

namespace VirtusPecto.Desktop{
	public class Lobby : Screen{
		OptionBox difficultyBox;
		Button start;
		Button settings;
		Button exit;
		Button play;

		public Lobby(){
			start = new Button("Start", () => {
				if(difficultyBox == null){
					difficultyBox = new OptionBox("Enemies", 10, "\0", Enumerable.Range(0, 10).Select(i => new Vector2((i + 1)*5, 1)).ToArray(), ()=>{});
				}else{
					difficultyBox = null;
				}
			});

			settings = new Button("Settings", () => {
				Settings = new SettingsMenu();
				Game1.Screen = Settings;
			});

			exit = new Button("Exit", () => {Environment.Exit(0);});

			play = new Button("Play", ()=>{
					Level1 = new Level((int)difficultyBox.Options[difficultyBox.Option].X);
					Level1.Creation();
					StartMenu = null;
					Game1.Screen = Level1;
				}
			);
		}
		public override void Update() {
			start.Update(Width/4, Height/2.4f);
			settings.Update(Width/4, Height/2.1f);
			exit.Update(Width / 4, Height / 1.85f);

			if (difficultyBox != null) {
				difficultyBox.Update(start.position.X + 128, start.position.Y);
				play.Update(start.position.X + 256, start.position.Y);
			}
		}
		public override void Draw(SpriteBatch batch) {
			batch.Draw(SpriteLogo, new Vector2(Width/2 - 480, Height/4 - 64*2), null, new Color(79,79,79), 0, Vector2.Zero, 2, SpriteEffects.None, 1);
			batch.Draw(SpriteTitle, new Vector2(Width/2+64, Height/4), null,Color.White, 0, new Vector2(SpriteTitle.Width, SpriteTitle.Height)/2, 8, SpriteEffects.None, 1);

			start.Draw(batch);
			settings.Draw(batch);
			exit.Draw(batch);

			if (difficultyBox != null) {
				difficultyBox.Draw(batch);
				play.Draw(batch);
			}
		}
	}
}
