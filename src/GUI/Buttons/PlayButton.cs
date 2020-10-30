using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class PlayButton : Button{
		public bool isActivated;
		private DifficultyBox difficultyBox;
		Button Play;
		
		public PlayButton():base("Start", () => {}){
			action = () => {
				isActivated = !isActivated;
			};
			Play = new Button("Play", ()=>{
					Game1.GoToLevel(1);
					Level1 = new Level((int)difficultyBox.Options[difficultyBox.Option].X);
					Level1.Creation();
					StartMenu = null;}
			);
		}

		public override void Update(float x, float y) {
			base.Update(x, y);
			if (isActivated) {
				if(difficultyBox == null){
					difficultyBox = new DifficultyBox((int)position.X+128,(int)position.Y);
				}
				difficultyBox.Update(position.X + 128, position.Y);
				Play.Update(position.X + 256, position.Y);
			}
		}
		public override void Draw(SpriteBatch batch) {
			if (isActivated) {
				difficultyBox.Draw(batch);
				Play.Draw(batch);
			}
			base.Draw(batch);
		}
	}
}
