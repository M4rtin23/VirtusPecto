using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirtusPecto.Desktop{
    public struct CardContent{
		public Texture2D Sprite;
		public string Name;
		public float Spd, Atk, HP, Dist;

		public CardContent(Texture2D sprite, string name, float speed, float attack, float hp, float distance){
			Sprite = sprite;
			Name = name;
            Spd = speed;
            Atk = attack;
            HP = hp;
            Dist = distance;
		}
    }
}
