using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
	}
}
