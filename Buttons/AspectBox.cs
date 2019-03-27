using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class AspectBox{
		public Rectangle GetCollision;
        public Texture2D BoxSprite;
        public Vector2 BoxPosition;
		public Color color;
        public float[] Ratios;
		public Color[] Colors;
		public Rectangle[] Rectangles;
		public bool isActivated;
		public int OptionsNumber;
        private string aspectRatio = "16:9";
        private string[] aspectRatios;

        public AspectBox(int x, int y){
			BoxSprite = Sprite2;
			OptionsNumber = 4;
			Ratios = new float[OptionsNumber];
            aspectRatios = new string[OptionsNumber];
			Colors = new Color[OptionsNumber];
			Rectangles = new Rectangle[OptionsNumber];
            BoxPosition = new Vector2(x, y);
			GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);

			for (int i = 0; i < OptionsNumber; i++){
				Ratios[i] = 16/9f;
                aspectRatios[i] = "16:9";
            }
			Ratios[1] = 16/10f;
			Ratios[2] = 4/3f;
			Ratios[3] = 5/4f;
            aspectRatios[1] = "16:10";
            aspectRatios[2] = "4:3";
            aspectRatios[3] = "5:4";

			for (int i = 0; i < OptionsNumber; i++){                
				Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (i+1) * 32, 128, 32);
                Colors[i] = Color.DarkGray;
            }
		}
		public void Collision() {
            GetCollision = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y, 128, 32);
            for (int i = 0; i < OptionsNumber; i++){
                Rectangles[i] = new Rectangle((int)BoxPosition.X, (int)BoxPosition.Y + (1 + i)*32, 128, 32);
			}
			if (GetCollision.Intersects(mouse.GetCollision)){
                if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/ IsClicking){
					isActivated = !isActivated;
                    System.Threading.Thread.Sleep(50);
                }
            }
			if (isActivated){
				for (int i = 0; i < OptionsNumber; i++){
					if (mouse.GetCollision.Intersects(Rectangles[i])){
						if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
							Settings.AspectRatio = Ratios[i];
                            aspectRatio = aspectRatios[i];
                            isActivated = false;
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
            spriteBatch.DrawString(Font, " " + aspectRatio, BoxPosition, Color.White);
			spriteBatch.DrawString(Font, "Aspect Ratio", new Vector2(BoxPosition.X, BoxPosition.Y - 32), Color.White);

			if (isActivated) {
				color = Color.LightGray;
				for (int i = 0; i < OptionsNumber; i++){
					spriteBatch.Draw(BoxSprite, new Vector2(BoxPosition.X, BoxPosition.Y+(1+i)*32), Colors[i]);
					spriteBatch.DrawString(Font, " " + aspectRatios[i], new Vector2(BoxPosition.X, BoxPosition.Y + (i+1) * 32), Color.White);
				}

			}else{
				color = Color.DarkGray;
			}
		}
    }
}
