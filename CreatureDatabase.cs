using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class CreatureDatabase{
		public static CardContent[] Creatures;
		public CreatureDatabase() {
			Creatures = new CardContent[3];
			Creatures[0] = new CardContent(CreatureSprite[0], "Elf", "Description", 4f, 0);
			Creatures[1] = new CardContent(CreatureSprite[1], "Wizard", "Description",1.5f, 300f);
			Creatures[2] = new CardContent(CreatureSprite[2], "Witch", "Description", 2f, 0);
            for(int i = 0; i < 3; i++){
                Creatures[i].Description = Creatures[i].Name + "*Atk: null"+"*HP: null" + "*Speed: " + Creatures[i].Spd;
                Creatures[i].Description = Creatures[i].Description.Replace("*", System.Environment.NewLine);
            }
		}
	}   
}
