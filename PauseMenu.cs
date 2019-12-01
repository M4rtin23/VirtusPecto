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
			settings = new SettingsButton((Width()/2)-48,Height()/2);
			ContinueRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) - 48 * 2, 128, 32);
			MainMenuRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) - 48, 128, 32);
			ExitRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) + 48, 128, 32);
		}
		public void Update() {
			settings.Collision();
			if (ContinueRectangle.Intersects(Mouse1.Hitbox)){
				if (/*Mouse1.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					IsPaused = false;
				}
				ContinueColor = Color.Red;
			}
			else {
				ContinueColor = Color.White;            
			}
			if (MainMenuRectangle.Intersects(Mouse1.Hitbox)){
				if (/*Mouse1.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
                    Levels = null;
					IsPaused = false;
					StartMenu = new Lobby();
                    GoToLevel(0);
				}
				MainMenuColor = Color.Red;
            }else {
                MainMenuColor = Color.White;            
            }
			if (ExitRectangle.Intersects(Mouse1.Hitbox)){
				ExitColor = Color.Red;
				if (/*Mouse1.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					WannaExit = true;
				}
            }else {
                ExitColor = Color.White;            
            }
		}
		public void Draw(SpriteBatch sprBt) {
			sprBt.Draw(Sprite2, new Vector2((Width() / 2), Height() / 2), new Rectangle(0, 0, 128, 32), Color.Black, 0, new Vector2(64, 16), new Vector2(2, 10), SpriteEffects.None, 0);
			sprBt.DrawString(Font, "Continue", new Vector2((Width() / 2)-48, (Height() / 2)-48*2), ContinueColor);
			sprBt.DrawString(Font, "Main Menu", new Vector2((Width() / 2) - 48, (Height() / 2) - 48), MainMenuColor);
            settings.SetPosition((Width()/2)-48,Height()/2);
			settings.Draw(sprBt);
			sprBt.DrawString(Font, "Exit", new Vector2((Width() / 2)-48, (Height() / 2)+48), ExitColor);
		}
    }
}
