﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Fullscreen : TickBox{
		public Fullscreen(int x, int y){
            name = "Fullscreen";
            state = graphics.IsFullScreen;
		}
        protected override void action(){
		    graphics.IsFullScreen = state;
	    	graphics.ApplyChanges();

        }
    }
}