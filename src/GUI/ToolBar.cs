using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static GameBuilder.GameBase
;

namespace VirtusPecto.Desktop{
	public class ToolBar{
		public void Draw(SpriteBatch batch) {
			batch.Draw(Sprite2, new Vector2(0, 0), new Rectangle(0, 0, Width,40), Color.Black, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0);         
			batch.Draw(Sprite2, new Vector2(8, 8), new Rectangle(0, 0, (int)(128*Level1.Player1.Health/100),24), Color.Red, 0, new Vector2(0, 0), new Vector2(1 , 1), SpriteEffects.None, 0);
			batch.Draw(Sprite2, new Vector2(164, 8), new Rectangle(0, 0, (int)(128*Level1.Player1.Mana/50),24), Color.DeepSkyBlue, 0, new Vector2(0, 0), new Vector2(1 , 1), SpriteEffects.None, 0);
			batch.DrawString(Font, Convert.ToString(Level1.Player1.Health) + "/100", new Vector2(32, 2), Color.White);
			batch.DrawString(Font, Convert.ToString(Level1.Player1.Mana) + "/50", new Vector2(196, 2), Color.White);
		}
	}
}
