﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
	public class PlayButton{
		public Rectangle Hitbox;
		private Vector2 position;
		public bool isActivated;
		private int transparency;
		public DifficultyBox HardnessBox;
		public Vector2 PlayPosition;
		public Rectangle PlayRectangle;
		private int playAlpha;
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
			if (Hitbox.Contains(Mouse1.Position)){
				transparency = 64;
				if(IsClicking()){
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
				if(HardnessBox == null){
					HardnessBox = new DifficultyBox((int)position.X+128,(int)position.Y);
				}
				HardnessBox.BoxPosition = position+ new Vector2(128, 0);
				HardnessBox.Collision();
				if (PlayRectangle.Contains(Mouse1.Position)) {
					playAlpha = 64;
					if (IsClicking()) {
						Game1.GoToLevel(1);
						switch(HardnessBox.Difficulty){
							case "Easy":
								Level1 = new Level(0);
								break;
							case "Normal":
								Level1 = new Level(3);
								break;
							case "Difficult":
								Level1 = new Level(5);
								break;
							default:
								Level1 = new Level(1);
								break;
						}
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
				HardnessBox.Draw(batch);
				GameBuilder.Builder.DrawRectangle(batch, PlayRectangle, new Color(playAlpha, playAlpha, playAlpha, playAlpha));
				batch.DrawString(Font, "Play", PlayPosition, Color.White);
			}
		}
	}
}
