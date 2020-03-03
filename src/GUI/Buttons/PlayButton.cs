using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
	public class PlayButton{
		public Rectangle Hitbox{get => new Rectangle((int)position.X,(int)position.Y,128,32);}
		private Vector2 position;
		public bool isActivated;
		private int transparency;
		private DifficultyBox difficultyBox;
		public Vector2 PlayPosition;
		public Rectangle PlayRectangle{get => new Rectangle((int)PlayPosition.X,(int) PlayPosition.Y, 128, 32);}
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
				if(IsClicking){
					checker = true;
				}else if(checker) {
					isActivated = !isActivated;
					checker = false;
				}
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
			GameBuilder.Builder.DrawRectangle(batch, Hitbox, new Color(transparency, transparency, transparency, transparency));
			batch.DrawString(Font, "Start", position, Color.White);
			if (isActivated) {
				difficultyBox.Draw(batch);
				GameBuilder.Builder.DrawRectangle(batch, PlayRectangle, new Color(playAlpha, playAlpha, playAlpha, playAlpha));
				batch.DrawString(Font, "Play", PlayPosition, Color.White);
			}
		}
	}
}
