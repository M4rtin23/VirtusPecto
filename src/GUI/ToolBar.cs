using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;
using static GameBuilder.GameType.FixedView;


namespace VirtusPecto.Desktop{
	public class ToolBar{
		public void Draw(SpriteBatch batch) {

			new RectangleF(128, Height-96, Width, 96, new Color(0,0,0,128)).Draw(batch);
			new RectangleF(Width-8-128 * Level1.Player1.Health/100, 8+Height-32-32, 128 * Level1.Player1.Health/100, 8, Color.Red).Draw(batch);
			new RectangleF(Width-8-128 * Level1.Player1.Mana/50, Height-16, 128 * Level1.Player1.Mana/50, 8, Color.DeepSkyBlue).Draw(batch);

//			batch.DrawString(FontBig, ""+(60 - GlobalGameTime.TotalGameTime.Seconds), new Vector2(132, Height - 118), Color.White);
//			batch.DrawString(FontNormal, Level1.CountEnemies()+" Enemies Left", new Vector2(132, Height - 100), Color.White);
			batch.DrawString(FontNormal, Level1.Player1.Health + "/100", new Vector2(Width-128, Height-64-24), Color.White);
			batch.DrawString(FontNormal, Level1.Player1.Mana + "/50", new Vector2(Width-128, Height-24-24), Color.White);
						
			int alpha = (int)(Level1.Player1.Power.Percentage*155+100);
			int alpha1 = (int)(Level1.Player1.Power.Percentage)*128+128;
			batch.Draw(SpritePowers, Vector2.UnitY*(Game1.Height-128), new Rectangle(0, 0, 128,128), new Color(30+90*(Convert.ToInt16(Level1.Player1.Power.Cost > Level1.Player1.Mana)),30,30,alpha/2));
			batch.Draw(SpritePowers, Vector2.UnitY*(Game1.Height-128), new Rectangle(128*(Level1.Player1.Power.Index), 0, 128,128), new Color(alpha1,alpha1,alpha1,alpha1));
		}
	}
}
