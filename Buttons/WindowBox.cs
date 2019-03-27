using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class WindowBox{
		public Rectangle GetCollision;
        public Texture2D BoxSprite;
        public Vector2 BoxPosition;
		public Color color;
        public Vector2[] Resolutions;
		public Color[] Colors;
		public Rectangle[] Rectangles;
		public bool isActivated;
		public int OptionsNumber;

        public WindowBox(int x, int y){
			BoxSprite = Sprite2;
			OptionsNumber = 8;
			Resolutions = new Vector2[OptionsNumber];
			Colors = new Color[OptionsNumber];
			Rectangles = new Rectangle[OptionsNumber];
            BoxPosition = new Vector2(x, y);
			GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);

			for (int i = 0; i < OptionsNumber; i++){
				Resolutions[i] = new Vector2(1366, 768);
			}/*
            Resolutions[0] = new Vector2(1280, 720);
            Resolutions[1] = new Vector2(1280, 1024);
			Resolutions[3] = new Vector2(1600, 900);
			Resolutions[4] = new Vector2(1920, 1080);
            */
            Resolutions[0].Y = 1200;
            Resolutions[1].Y = 1080;
            Resolutions[2].Y = 1050;
			Resolutions[3].Y = 1024;
			Resolutions[4].Y = 900;
			Resolutions[5].Y = 800;
			Resolutions[7].Y = 720;

			for (int i = 0; i < OptionsNumber; i++){                
				Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (1+i)*32, 128, 32);
                Colors[i] = Color.DarkGray;
            }
		}
		public void Collision() {
            GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);
            for (int i = 0; i < OptionsNumber; i++){
                Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (1 + i)*32, 128, 32);
				Resolutions[i].X = (float)Math.Ceiling(Settings.AspectRatio * Resolutions[i].Y);
			}
			if (GetCollision.Intersects(mouse.GetCollision)){
                if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
					isActivated = !isActivated;
                    System.Threading.Thread.Sleep(50);
                }
            }
			if (isActivated){
				for (int i = 0; i < OptionsNumber; i++){
					if (mouse.GetCollision.Intersects(Rectangles[i])){
						if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
							graphics.PreferredBackBufferWidth = (int)Resolutions[i].X;
							graphics.PreferredBackBufferHeight = (int)Resolutions[i].Y;
                            isActivated = false;
							graphics.ApplyChanges();
						}
						Colors[i] = Color.LightBlue;}
					else{
						Colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public void Draw() {
			spriteBatch.Draw(BoxSprite, BoxPosition, color);
            spriteBatch.DrawString(Font, " "+Convert.ToString(graphics.PreferredBackBufferWidth) + " X " + Convert.ToString(graphics.PreferredBackBufferHeight), BoxPosition, Color.White);
			spriteBatch.DrawString(Font, "Window Size", new Vector2(BoxPosition.X, BoxPosition.Y - 32), Color.White);

			if (isActivated) {
				color = Color.LightGray;
				for (int i = 0; i < OptionsNumber; i++){
					spriteBatch.Draw(BoxSprite, new Vector2(BoxPosition.X, BoxPosition.Y+(1+i)*32), Colors[i]);
					spriteBatch.DrawString(Font, " "+Convert.ToString(Resolutions[i].X) + " X " + Convert.ToString(Resolutions[i].Y), new Vector2(BoxPosition.X, BoxPosition.Y + (i+1) * 32), Color.White);
				}

			}else{
				color = Color.DarkGray;
			}
		}
    }
}
