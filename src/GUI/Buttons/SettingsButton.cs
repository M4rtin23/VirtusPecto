using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class SettingsButton{
		public RectangleF Hitbox{get => new RectangleF(position.X, position.Y,128,32);}
		public Vector2 position = Vector2.Zero;
		private int transparency = 0;
		bool checker;

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
		public void Draw(float x, float y, SpriteBatch batch){
			position.X = x;
			position.Y = y;
			Hitbox.Draw(batch, new Color(transparency, transparency, transparency, transparency));
			batch.DrawString(FontNormal, "Settings", position, Color.White);
		}
	}
}
