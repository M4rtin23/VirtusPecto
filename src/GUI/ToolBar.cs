using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using static GameBuilder.GameBase;


namespace VirtusPecto.Desktop{
	public class ToolBar{
		public void Draw(SpriteBatch batch) {

			new RectangleF(0, 0, Width, 40, Color.Black).Draw(batch);
			new RectangleF(8, 8, 128 * Level1.Player1.Health/100, 24, Color.Red).Draw(batch);
			new RectangleF(164, 8, 128 * Level1.Player1.Mana/50, 24, Color.DeepSkyBlue).Draw(batch);

			batch.DrawString(FontNormal, Convert.ToString(Level1.Player1.Health) + "/100", new Vector2(32, 2), Color.White);
			batch.DrawString(FontNormal, Convert.ToString(Level1.Player1.Mana) + "/50", new Vector2(196, 2), Color.White);
		}
	}
}
