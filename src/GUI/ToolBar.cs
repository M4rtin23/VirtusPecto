using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;

namespace VirtusPecto.Desktop{
    public class ToolBar{

		public ToolBar(){
			
		}
		public void Draw(SpriteBatch sprBt) {
			sprBt.Draw(Sprite2, new Vector2(0, 0), new Rectangle(0, 0, Width(),40), Color.Black, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0);         
			sprBt.Draw(Sprite2, new Vector2(8, 8), new Rectangle(0, 0, (int)(128*Level1.Player1.Health/100),24), Color.Red, 0, new Vector2(0, 0), new Vector2(1 , 1), SpriteEffects.None, 0);
			sprBt.Draw(Sprite2, new Vector2(164, 8), new Rectangle(0, 0, (int)(128*Level1.Player1.Mana/100),24), Color.DeepSkyBlue, 0, new Vector2(0, 0), new Vector2(1 , 1), SpriteEffects.None, 0);
			sprBt.DrawString(Font, Convert.ToString(Level1.Player1.Health) + "/100", new Vector2(32, 2), Color.White);
			sprBt.DrawString(Font, Convert.ToString(Level1.Player1.Mana) + "/100", new Vector2(196, 2), Color.White);
		}
    }
}
