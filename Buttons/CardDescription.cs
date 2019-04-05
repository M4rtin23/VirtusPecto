using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class CardDescription : TickBox{
        public CardDescription(){
            state = IsDescriptionOn;
            name = "Show Description";
        }
        protected override void update(){
            IsDescriptionOn = state;
        }
    }
}
