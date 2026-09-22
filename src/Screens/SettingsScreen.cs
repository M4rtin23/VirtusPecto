using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;﻿
using static GameBuilder.GameType.FixedView;
namespace VirtusPecto.Desktop{
	public class SettingsScreen : GameBuilder.Screens.Screen{
		protected UIElement[] settings;
		int gridWidth = 1;
		Vector2 displacement, placement;

		public SettingsScreen(UIElement[] settings, int gridWidth){
			this.settings = settings;
			this.gridWidth = gridWidth;
		}
		public override void Update() {
			displacement = new Vector2(Width/(gridWidth+1), Height/(4+(int)(settings.Length/gridWidth)));
			for(int i = 0; i < settings.Length; i++){
				settings[i].Update((i % gridWidth + 1)*displacement.X - 64, (i / gridWidth + 2) * displacement.Y);
			}
		}
		public override void Draw(SpriteBatch batch) {
			for(int i = settings.Length; i > 0; i--){
				settings[i-1].Draw(batch);
			}
		}
	}
}
