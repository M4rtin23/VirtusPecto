using System;
using static VirtusPecto.Desktop.Game1;
using System.IO;

namespace VirtusPecto.Desktop{
    public class CreatureDatabase{
        public static CardContent GetData(int i){
            string[] l;
            l = File.ReadAllLines("/home/martin/Documentos/Projectos/C#/VirtusPecto/src/Database/Creatures.csv");
            l = l[i+1].Split(';');
            return new CardContent(CreatureSprite[i],l[1],(float)Convert.ToDecimal(l[2]),(float)Convert.ToDecimal(l[3]),(float)Convert.ToDecimal(l[4]),(float)Convert.ToDecimal(l[5]));
        }
	}   
}
