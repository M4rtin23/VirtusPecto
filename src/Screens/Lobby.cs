using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameType.FixedView;
using GameBuilder.UI;
using System.Linq;

namespace VirtusPecto.Desktop{
	public class Lobby : GameBuilder.Screens.Screen{
		OptionBox difficultyBox;
		Button start, play;
		UIContainer UIContainer;
		public Lobby(){
			start = new Button("Start", () => {
				if(difficultyBox == null){
					difficultyBox = new OptionBox("Enemies", 10, "\0", Enumerable.Range(0, 10).Select(i => new Vector2((i + 1)*5, 1)).ToArray(), ()=>{});
				}else{
					difficultyBox = null;
				}
			});
			play = new Button("Play", ()=>{
				Level1 = new Level((int)difficultyBox.Options[difficultyBox.Option].X);
				StartMenu = null;
				Game1.Screen = Level1;
			});
			UIContainer = new UIContainer([start, new Button("Settings", () => {Settings = new SettingsMenu(); Game1.Screen = Settings;}), new Button("Exit", () => {Environment.Exit(0);}) ], 1, new GameBuilder.Shapes.RectangleF(Width/4, Height/2.4f, 200, Height/2));
		}
		public override void Update() {
			UIContainer.ViewArea = new GameBuilder.Shapes.RectangleF(Width/4, Height/2.4f, 200, Height/2);
			UIContainer.Update();
			if (difficultyBox != null) {
				difficultyBox.Update(start.position.X + 128, start.position.Y);
				play.Update(start.position.X + 256, start.position.Y);
			}
		}
		public override void Draw(SpriteBatch batch) {
			batch.Draw(Sprites["Logo"], new Vector2(Width/2 - 480, Height/4 - 64*2), null, new Color(79,79,79), 0, Vector2.Zero, 2, SpriteEffects.None, 1);
			batch.Draw(Sprites["Title"], new Vector2(Width/2+64, Height/4), null,Color.White, 0, new Vector2(Sprites["Title"].Width, Sprites["Title"].Height)/2, 8, SpriteEffects.None, 1);
			UIContainer.Draw(batch);
			if (difficultyBox != null) {
				difficultyBox.Draw(batch);
				play.Draw(batch);
			}
		}
	}
}
