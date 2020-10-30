using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using static VirtusPecto.Desktop.Game1;


namespace VirtusPecto.Desktop{
	public struct CardContent{
		public Texture2D Sprite;
		public string Name;
		public float Spd, Atk, HP, Dist;
		public int PowerIndex, Cost;

		public CardContent(Texture2D sprite, string name, float speed, float attack, float hp, float distance, int powerIndex, int cost){
			Sprite = sprite;
			Name = name;
			Spd = speed;
			Atk = attack;
			HP = hp;
			Dist = distance;
			PowerIndex = powerIndex;
			Cost = cost;
		}
		public static CardContent GetData(int i){
			string[] l;
			l = File.ReadAllLines("src/Database/Creatures.csv");
			l = l[i+1].Split(';');
			return new CardContent(
				SpriteCreatures[i],l[1],
				(float)Convert.ToDecimal(l[2]),
				(float)Convert.ToDecimal(l[3]),
				(float)Convert.ToDecimal(l[4]),
				(float)Convert.ToDecimal(l[5]),
				Convert.ToInt16(l[6]),
				Convert.ToInt16(l[7])
			);
		}
	}
}
