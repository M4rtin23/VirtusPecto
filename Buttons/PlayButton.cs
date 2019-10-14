using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
    public class PlayButton{
		public Rectangle Hitbox;
		private Vector2 position;
		public Color WordColor;
		public bool isActivated;
		public DifficultyBox HardnessBox;
		public Vector2 PlayPosition;
		public Rectangle PlayRectangle;
		public Color PlayColor;
        bool checker;

        public PlayButton(int x, int y){
			position = new Vector2(x, y);
			Hitbox = new Rectangle((int)position.X,(int)position.Y,64,32);
			PlayPosition = new Vector2(0, 0);
			//HardnessBox = new DifficultyBox((int)position.X+128,(int)position.Y+44);
			PlayRectangle = new Rectangle((int)PlayPosition.X,(int) PlayPosition.Y, 128, 32);
        }
        public void SetPosition(float x, float y){
            position.X = x;
            position.Y = y;
        }
		public void Collision() {
			PlayPosition = new Vector2(position.X + 256, position.Y);
			PlayRectangle = new Rectangle((int)PlayPosition.X,(int) PlayPosition.Y, 128, 32);
			Hitbox = new Rectangle((int)position.X,(int)position.Y,64,32);            
			if (Hitbox.Intersects(mouse.Hitbox)){
				WordColor = Color.Red;
                if(IsClicking){
                    checker = true;
                }
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/!IsClicking && checker) {
					isActivated = !isActivated;
                    checker = false;
				}
			}
			else {
				WordColor = Color.White;
			}
			if (isActivated) {
                if(HardnessBox == null){
                    HardnessBox = new DifficultyBox((int)position.X+128,(int)position.Y);
                }
                HardnessBox.BoxPosition = position+ new Vector2(128, 0);
				HardnessBox.Collision();
				if (PlayRectangle.Intersects(mouse.Hitbox)) {
					PlayColor = Color.Red;
					if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
						LevelNumber = 1;
                        switch(HardnessBox.Difficulty){
                            case "Easy":
				        		Levels = new Level(0);
                                break;
                            case "Normal":
		        				Levels = new Level(3);
                                break;
                            case "Difficult":
        						Levels = new Level(5);
                                break;
                            default:
                                Levels = new Level(1);
                                break;
                        }
                        Levels.Creation();
						StartMenu = null;
					}
				}else{
					PlayColor = Color.White;
				}
			}
		}
		public void Draw(SpriteBatch sprBt) {
			sprBt.DrawString(Font, "Start", position, WordColor);
			if (isActivated) {
				HardnessBox.Draw(sprBt);
				sprBt.DrawString(Font, "Play", PlayPosition,PlayColor);
			}
		}
    }
}
