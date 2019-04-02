﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
    public class PlayButton{
		public Rectangle GetCollision;
		private Vector2 position;
		public Color WordColor;
		public bool isActivated;
		public DifficultyBox HardnessBox;
		public Vector2 PlayPosition;
		public Rectangle PlayRectangle;
		public Color PlayColor;

        public PlayButton(int x, int y){
			position = new Vector2(x, y);
			GetCollision = new Rectangle((int)position.X,(int)position.Y,64,32);
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
			GetCollision = new Rectangle((int)position.X,(int)position.Y,64,32);            
			if (GetCollision.Intersects(mouse.GetCollision)){
				WordColor = Color.Red;
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					isActivated = !isActivated;
					System.Threading.Thread.Sleep(50);
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
				if (PlayRectangle.Intersects(mouse.GetCollision)) {
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
		public void Draw() {
			spriteBatch.DrawString(Font, "Start", position, WordColor);
			if (isActivated) {
				HardnessBox.Draw();
				spriteBatch.DrawString(Font, "Play", PlayPosition,PlayColor);
			}
		}
    }
}