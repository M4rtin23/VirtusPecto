using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class PowerIndicator{
		private Vector2 position;
		private static float timer;

		public void Update(){
			position = new Vector2(0, Game1.Height-128);
			if(timer > 0){
				timer--;
			}
		}

		public void Draw(SpriteBatch batch){
			int alpha = (int)((60-timer)/60*155+100);
			int alpha1 = (60-(int)timer)/60*128+128;
			batch.Draw(Game1.SpritePowers, position, new Rectangle(0, 0, 128,128), new Color(30+90*(Convert.ToInt16(Level1.Player1.ManaCost[Level1.Player1.GetPowerIndex()] > Level1.Player1.Mana)),30,30,alpha/2));
			batch.Draw(Game1.SpritePowers, position, new Rectangle(128*(Level1.Player1.GetPowerIndex()+1), 0, 128,128), new Color(alpha1,alpha1,alpha1,alpha1));
		}

		public static bool IsCharged(){
			return timer <= 0;
		}
		public static bool CanShoot(){
			bool i = timer <= 0;
			if(i){
				timer = 60;
			}
			return i;
		}
	}
}