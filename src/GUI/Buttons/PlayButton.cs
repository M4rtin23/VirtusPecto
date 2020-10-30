using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class PlayButton{
		public RectangleF Hitbox{get => new RectangleF(position.X, position.Y,128,32);}
		private Vector2 position;
		public bool isActivated;
		private int transparency;
		private DifficultyBox difficultyBox;
		public Vector2 PlayPosition;
		public RectangleF PlayRectangle{get => new RectangleF(PlayPosition.X, PlayPosition.Y, 128, 32);}
		private int playAlpha;
		bool checker;

		public PlayButton(int x, int y){
			PlayPosition = new Vector2(0, 0);
		}
		public void SetPosition(float x, float y){
			position.X = x;
			position.Y = y;
		}
		public void Collision() {
			PlayPosition = new Vector2(position.X + 256, position.Y);
			if (Hitbox.Contains(Mouse1.Position)){
				transparency = 64;
				GameMouse.Click(() => {isActivated = !isActivated;}, ref checker);
			}
			else {
				transparency = 0;
			}
			if (isActivated) {
				if(difficultyBox == null){
					difficultyBox = new DifficultyBox((int)position.X+128,(int)position.Y);
				}
				difficultyBox.SetPosition(position.X + 128, position.Y);
				difficultyBox.Collision();
				if (PlayRectangle.Contains(Mouse1.Position)) {
					playAlpha = 64;
					if (IsClicking) {
						Game1.GoToLevel(1);
						Level1 = new Level((int)difficultyBox.Options[difficultyBox.Option].X);
						Level1.Creation();
						StartMenu = null;
					}
				}else{
					playAlpha = 0;
				}
			}
		}
		public void Draw(SpriteBatch batch) {
			Hitbox.Draw(batch, new Color(transparency, transparency, transparency, transparency));
			batch.DrawString(FontNormal, "Start", position, Color.White);
			if (isActivated) {
				difficultyBox.Draw(batch);
				PlayRectangle.Draw(batch, new Color(playAlpha, playAlpha, playAlpha, playAlpha));
				batch.DrawString(FontNormal, "Play", PlayPosition, Color.White);
			}
		}
	}
}
