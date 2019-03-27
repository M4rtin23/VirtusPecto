using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class PauseMenu{
		public SettingsButton settings;
		public Rectangle ContinueRectangle, MainMenuRectangle, ExitRectangle;
		public Color ContinueColor, MainMenuColor, ExitColor;
		public PauseMenu(){
			settings = new SettingsButton((graphics.PreferredBackBufferWidth/2)-48,graphics.PreferredBackBufferHeight/2);
			ContinueRectangle = new Rectangle((graphics.PreferredBackBufferWidth / 2) - 48, (graphics.PreferredBackBufferHeight / 2) - 48 * 2, 128, 32);
			MainMenuRectangle = new Rectangle((graphics.PreferredBackBufferWidth / 2) - 48, (graphics.PreferredBackBufferHeight / 2) - 48, 128, 32);
			ExitRectangle = new Rectangle((graphics.PreferredBackBufferWidth / 2) - 48, (graphics.PreferredBackBufferHeight / 2) + 48, 128, 32);
		}
		public void Update() {
			settings.Collision();
			if (ContinueRectangle.Intersects(mouse.GetCollision)){
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					IsPaused = false;
				}
				ContinueColor = Color.Red;
			}
			else {
				ContinueColor = Color.White;            
			}
			if (MainMenuRectangle.Intersects(mouse.GetCollision)){
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
                    Levels = null;
					IsPaused = false;
					StartMenu = new Lobby();
					LevelNumber = 0;
				}
				MainMenuColor = Color.Red;
            }else {
                MainMenuColor = Color.White;            
            }
			if (ExitRectangle.Intersects(mouse.GetCollision)){
				ExitColor = Color.Red;
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					WannaExit = true;
				}
            }else {
                ExitColor = Color.White;            
            }
		}
		public void Draw() {
			spriteBatch.Draw(Sprite2, new Vector2((graphics.PreferredBackBufferWidth / 2), graphics.PreferredBackBufferHeight / 2), new Rectangle(0, 0, 128, 32), Color.Black, 0, new Vector2(64, 16), new Vector2(2, 10), SpriteEffects.None, 0);
			spriteBatch.DrawString(Font, "Continue", new Vector2((graphics.PreferredBackBufferWidth / 2)-48, (graphics.PreferredBackBufferHeight / 2)-48*2), ContinueColor);
			spriteBatch.DrawString(Font, "Main Menu", new Vector2((graphics.PreferredBackBufferWidth / 2) - 48, (graphics.PreferredBackBufferHeight / 2) - 48), MainMenuColor);
            settings.SetPosition((graphics.PreferredBackBufferWidth/2)-48,graphics.PreferredBackBufferHeight/2);
			settings.Draw();
			spriteBatch.DrawString(Font, "Exit", new Vector2((graphics.PreferredBackBufferWidth / 2)-48, (graphics.PreferredBackBufferHeight / 2)+48), ExitColor);
		}
    }
}
