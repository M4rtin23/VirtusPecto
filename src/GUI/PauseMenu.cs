using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.GameBase;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class PauseMenu{
		public SettingsButton settings = new SettingsButton();
		public RectangleF ContinueRectangle{get => new RectangleF((Width / 2) - 48, (Height / 2) - 48 * 2, 128, 32);}
		public RectangleF MainMenuRectangle{get => new RectangleF((Width / 2) - 48, (Height / 2) - 48, 128, 32);}
		public RectangleF ExitRectangle{get => new RectangleF((Width / 2) - 48, (Height / 2) + 48, 128, 32);}

		private int continueAlpha, mainmenuAlpha, exitAlpha;
		public void Update() {
			settings.Collision();
			#region continue
			if (ContinueRectangle.Contains(Mouse1.Position)){
				if (IsClicking) {
					IsPaused = false;
				}
				continueAlpha = 64;
			}
			else {
				continueAlpha = 0;
			}
			# endregion
			#region main menu
			if (MainMenuRectangle.Contains(Mouse1.Position)){
				if (IsClicking) {
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
			if (ExitRectangle.Contains(Mouse1.Position)){
				exitAlpha = 64;
				if (IsClicking) {
					WannaExit = true;
				}
			}else {
				exitAlpha = 0;            
			}
			#endregion
		}
		public void Draw(SpriteBatch batch) {
			batch.Draw(SpriteCard, new Vector2((Width / 2), Height / 2), null, new Color(0,0,0,128), 0, new Vector2(128, 160), new Vector2(1, 1), SpriteEffects.None, 0);

			ContinueRectangle.Draw(batch,new Color(continueAlpha,continueAlpha, continueAlpha, continueAlpha));
			MainMenuRectangle.Draw(batch,  new Color(mainmenuAlpha,mainmenuAlpha, mainmenuAlpha, mainmenuAlpha));
			ExitRectangle.Draw(batch, new Color(exitAlpha,exitAlpha, exitAlpha, exitAlpha));

			batch.DrawString(FontNormal, "Continue", new Vector2((Width / 2)-48, (Height / 2)-48*2), Color.White);
			batch.DrawString(FontNormal, "Main Menu", new Vector2((Width / 2) - 48, (Height / 2) - 48), Color.White);
			batch.DrawString(FontNormal, "Exit", new Vector2((Width / 2)-48, (Height / 2)+48), Color.White);			

			settings.Draw((Width/2)-48, Height/2,batch);

		}
	}
}
