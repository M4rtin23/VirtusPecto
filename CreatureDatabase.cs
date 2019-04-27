using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using System.IO;

namespace VirtusPecto.Desktop{
    public class CreatureDatabase{
		public static CardContent[] Creatures;
        public static CardContent GetData(int i){
            string[] l;
            l = File.ReadAllLines("/home/martin/Documentos/Projectos/C#/VirtusPecto/Creatures.csv");
            l = l[i+1].Split(';');
            CardContent cc = new CardContent(CreatureSprite[i],l[1],(float)Convert.ToDecimal(l[2]),(float)Convert.ToDecimal(l[3]),(float)Convert.ToDecimal(l[4]),(float)Convert.ToDecimal(l[5]));
            return cc;
        }
	}   
}
