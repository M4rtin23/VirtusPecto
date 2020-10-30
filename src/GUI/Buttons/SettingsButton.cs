using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
	public class SettingsButton{
		public Rectangle Hitbox{get => new Rectangle((int)position.X,(int)position.Y,128,32);}
		public Vector2 position;
		private int transparency = 0;
		bool checker;

		public SettingsButton(int x, int y){
			
		}
		public void SetPosition(float x, float y){
			position.X = x;
			position.Y = y;
		}

		public void Collision(){
			if (Hitbox.Contains(Mouse1.Position)){
				transparency = 64;
				GameMouse.Click(() => {Settings = new SettingsMenu();
					IsPaused = false;
					GoToLevel(2);
					Button1.isActivated = false;
				}, ref checker);
			}
			else{
				transparency = 0;
			}
		}
		public void Draw(SpriteBatch batch){
			GameBuilder.Builder.DrawRectangle(batch, Hitbox, new Color(transparency,transparency,transparency,transparency));
			batch.DrawString(FontNormal, "Settings", position, Color.White);
		}
	}
}
