using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Lobby{
		public static PlayButton Button1;
		public static SettingsButton Button2;
		public static Vector2 LogoPosition;
        private Color ExitColor;
        private Rectangle ExitRectangle;
        int g = 0;
        public Lobby(){
            BackGroundColor = Color.Black;
			Button1 = new PlayButton(Width()/4, (int)((float)Height()/2.4f));
			Button2 = new SettingsButton(Width()/4, (int)((float)Height()/2.11f));
			ExitRectangle = new Rectangle((Width() / 2)-48, (int)((float)Height() / 1.85f), 128, 32);
            LogoPosition = new Vector2(Width()/4f, 128);
		}
		public void Update() {
            if(Keyboard.GetState().IsKeyDown(Keys.Enter)){
            	System.Threading.Thread.Sleep(90);
                g++;
            }
			Button1.Collision();
			Button2.Collision();
            if (ExitRectangle.Intersects(mouse.GetCollision)){
				ExitColor = Color.Red;
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking) {
					WannaExit = true;
				}
            }else {
                ExitColor = Color.White;            
            }
//            Button1.SetPosition(Width()/4, (float)Height()/2.4f);
//            Button2.SetPosition(Width()/4, (float)Height()/2.1f);
            switch(g % 2){
                case 0:
                    Button1.SetPosition(Width()/4, (float)Height()/2.4f);
                    Button2.SetPosition(Width()/4, (float)Height()/2.1f);
                    ExitRectangle = new Rectangle((Width() / 4), (int)((float)Height() / 1.85f), 128, 32);
                    break;
                // case 1:
                //     Button1.SetPosition(Width()/3, (float)Height()/2.4f);
                //     Button2.SetPosition(Width()/3, (float)Height()/2.1f);
                //     ExitRectangle = new Rectangle((Width() / 3), (int)((float)Height() / 1.85f), 128, 32);
                //     break;
                 case 1:
                     Button1.SetPosition(Width()/2-52, (float)Height()/2.4f);
                     Button2.SetPosition(Width()/2-64, (float)Height()/2.1f);
                     ExitRectangle = new Rectangle((Width() / 2)-48, (int)((float)Height() / 1.85f), 128, 32);
                     break;
            //    case 1:
            //        Button1.SetPosition(Width()/2 - 128, (float)Height()/2.4f);
            //        Button2.SetPosition(Width()/2 - 128, (float)Height()/2.1f);
            //        ExitRectangle = new Rectangle((Width() / 2 - 128), (int)((float)Height() / 1.85f), 128, 32);
            //        break;
            }
			LogoPosition = new Vector2(Width() / 2f - 220, 128);
		}
		public void Draw(SpriteBatch sprBt) {
			sprBt.Draw(Logo, new Vector2(LogoPosition.X - 128, LogoPosition.Y), Color.White);
			sprBt.DrawString(Font2, "Virtus Pecto", new Vector2(LogoPosition.X, LogoPosition.Y), Color.White);
			Button1.Draw(sprBt);
			Button2.Draw(sprBt);
			sprBt.DrawString(Font, "Exit", new Vector2(ExitRectangle.X, ExitRectangle.Y), ExitColor);
            sprBt.DrawString(Font,Convert.ToString(g%3), new Vector2(0, 0), ExitColor);

		}
    }
}
