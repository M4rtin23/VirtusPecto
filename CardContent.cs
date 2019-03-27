using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirtusPecto.Desktop{
    public struct CardContent{
		public Texture2D Sprite;
		public string Name;
		public string Description;
		public float Spd,/*  Atk, HP,*/ Dist;

		public CardContent(Texture2D sprite,string name, string description, float speed, float distance){
			Sprite = sprite;
			Name = name;
			Description = description;
            Spd = speed;
            Dist = distance;
		}
    }
}
