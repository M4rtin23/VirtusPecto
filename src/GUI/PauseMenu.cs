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
		private int continueAlpha, mainmenuAlpha, exitAlpha;
		public PauseMenu(){
			settings = new SettingsButton((Width()/2)-48,Height()/2);
			ContinueRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) - 48 * 2, 128, 32);
			MainMenuRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) - 48, 128, 32);
			ExitRectangle = new Rectangle((Width() / 2) - 48, (Height() / 2) + 48, 128, 32);
		}
		public void Update() {
			settings.Collision();
			#region continue
            if (ContinueRectangle.Intersects(Mouse1.Hitbox)){
				if (IsClicking()) {
					IsPaused = false;
				}
				continueAlpha = 64;
			}
			else {
                continueAlpha = 0;
			}
            # endregion
            #region main menu
			if (MainMenuRectangle.Intersects(Mouse1.Hitbox)){
				if (IsClicking()) {
                    Level1 = null;
					IsPaused = false;
					StartMenu = new Lobby();
                    GoToLevel(0);
				}
				mainmenuAlpha = 64;
            }else {
                mainmenuAlpha = 0;            
            }
            #endregion
            #region exit
			if (ExitRectangle.Intersects(Mouse1.Hitbox)){
				exitAlpha = 64;
				if (IsClicking()) {
					WannaExit = true;
				}
            }else {
                exitAlpha = 0;            
            }
            #endregion
		}
		public void Draw(SpriteBatch sprBt) {
			//sprBt.Draw(Sprite2, new Vector2((Width() / 2), Height() / 2), new Rectangle(0, 0, 128, 32), new Color(0,0,0,128), 0, new Vector2(64, 16), new Vector2(2, 8), SpriteEffects.None, 0);
            sprBt.Draw(Sprite1, new Vector2((Width() / 2), Height() / 2), null, new Color(0,0,0,128), 0, new Vector2(128, 160), new Vector2(1, 1), SpriteEffects.None, 0);
            GameBuilder.Builder.DrawRectangle(sprBt, ContinueRectangle, new Color(continueAlpha,continueAlpha, continueAlpha, continueAlpha));
            sprBt.DrawString(Font, "Continue", new Vector2((Width() / 2)-48, (Height() / 2)-48*2), Color.White);
			GameBuilder.Builder.DrawRectangle(sprBt, MainMenuRectangle, new Color(mainmenuAlpha,mainmenuAlpha, mainmenuAlpha, mainmenuAlpha));
			sprBt.DrawString(Font, "Main Menu", new Vector2((Width() / 2) - 48, (Height() / 2) - 48), Color.White);
            settings.SetPosition((Width()/2)-48,Height()/2);
			settings.Draw(sprBt);
			GameBuilder.Builder.DrawRectangle(sprBt, ExitRectangle, new Color(exitAlpha,exitAlpha, exitAlpha, exitAlpha));
			sprBt.DrawString(Font, "Exit", new Vector2((Width() / 2)-48, (Height() / 2)+48), Color.White);
		}
    }
}
