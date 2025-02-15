using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using System.Linq;

namespace VirtusPecto.Desktop{
	public class PlayButton : Button{
		public bool isActivated;
		OptionBox difficultyBox;
		Button Play;
		
		public PlayButton():base("Start", () => {}){
			action = () => {
				isActivated = !isActivated;
			};
			Play = new Button("Play", ()=>{
					Level1 = new Level((int)difficultyBox.Options[difficultyBox.Option].X);
					Level1.Creation();
					StartMenu = null;
					Game1.Screen = Level1;
				}
			);
		}

		public override void Update(float x, float y) {
			base.Update(x, y);
			if (isActivated) {
				if(difficultyBox == null){
					difficultyBox = new OptionBox("Enemies", 10, Enumerable.Range(0, 10).Select(i => new Vector2((i + 1)*5, 1)).ToArray());
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
