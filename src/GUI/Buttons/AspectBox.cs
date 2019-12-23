using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class AspectBox : OptionBox{
        public AspectBox(){
            name = "Aspect Ratio";
            Options[0] = new Vector2(16f, 9f);
            Options[1] = new Vector2(16f, 10f);
            Options[2] = new Vector2(21f, 9f);
            Options[3] = new Vector2(4f, 3f);
            Options[4] = new Vector2(5f, 4f);
        }
        protected override int n(){
            return 5;
        }
        protected override void action(int i){
            Settings.AspectRatio = Options[i];
        }
        protected override string drawOptions(int i){
            string a = " "+Convert.ToString(Options[i].X) + ":" + Convert.ToString(Options[i].Y);
            return a;
        }
        protected override string currentOption(){
            string a = " "+Convert.ToString(Settings.AspectRatio.X) + ":" + Convert.ToString(Settings.AspectRatio.Y);
            return a;
        }

    }
}