﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class DifficultyBox{
		public Rectangle Hitbox;
        public Texture2D BoxSprite;
        public Vector2 BoxPosition;
        public Color color;
		public String[] Options;
        public Color[] Colors;
        public Rectangle[] Rectangles;
        public bool isActivated;
        public int OptionsNumber;
		public string Difficulty;
        bool checker;

        public DifficultyBox(int x, int y){
            BoxSprite = Sprite2;
			Difficulty = "Normal";
			OptionsNumber = 3;
			Options = new String[OptionsNumber];
            color = Color.LightGray;
            Colors = new Color[OptionsNumber];
            Rectangles = new Rectangle[OptionsNumber];
            BoxPosition = new Vector2(x,y);
            Hitbox = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);

			Options[0] = "Easy";
			Options[1] = "Normal";
			Options[2] = "Difficult";

			for (int i = 0; i < OptionsNumber; i++){
                Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (1 + i) * 32, 128, 32);
                Colors[i] = Color.DarkGray;
            }
		}
		public void Collision(){
            Hitbox = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);
            if(isActivated){
            }
            if (Hitbox.Contains(Mouse1.Position)){
                if(IsClicking()){
                    checker = true;
                }else if(checker){
                    isActivated = !isActivated;
                    checker = false;
                }
            }else{
                checker = false;
            }
            
            if (isActivated){
                for (int i = 0; i < OptionsNumber; i++){
                    if (Rectangles[i].Contains(Mouse1.Position)){
                        if (IsClicking()){
							Difficulty = Options[i];
                            isActivated = false;
                        }
                        Colors[i] = Color.LightBlue;
                    }else{
                        Colors[i] = Color.DarkGray;
                    }
                }
            }
        }
		public void Draw(SpriteBatch sprBt){
            sprBt.Draw(BoxSprite, BoxPosition, color);
			sprBt.DrawString(Font, " " + Difficulty, BoxPosition, Color.White);
            if (isActivated){
                color = Color.LightGray;
                for (int i = 0; i < OptionsNumber; i++){
                    sprBt.Draw(BoxSprite, new Vector2(BoxPosition.X, BoxPosition.Y + (1 + i) * 32), Colors[i]);
					sprBt.DrawString(Font, Options[i], new Vector2(BoxPosition.X, BoxPosition.Y + (i + 1) * 32), Color.White);
                }
            }else{
                color = Color.DarkGray;
            }
        }
    }
}
