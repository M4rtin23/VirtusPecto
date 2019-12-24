using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Lobby{
        public BackGround Background;
		public static PlayButton Button1;
		public static SettingsButton Button2;
		public static Vector2 LogoPosition;
        private int exitAlpha;
        private Rectangle ExitRectangle;
        int g = 0;
        bool checker;
        public Lobby(){
            Background = new BackGround(Back);
			Button1 = new PlayButton(Width()/4, (int)((float)Height()/2.4f));
			Button2 = new SettingsButton(Width()/4, (int)((float)Height()/2.11f));
			ExitRectangle = new Rectangle((Width() / 2)-48, (int)((float)Height() / 1.85f), 48, 32);
            LogoPosition = new Vector2(Width()/4f, 128);
		}
		public void Update() {
            if(Keyboard.GetState().IsKeyDown(Keys.Enter)){
                checker = true;
            }
            if(Keyboard.GetState().IsKeyUp(Keys.Enter) && checker){
                g++;
                checker = false;
            }
			Button1.Collision();
			Button2.Collision();
            if (ExitRectangle.Contains(Mouse1.Position)){
				exitAlpha = 64;
				if (IsClicking()) {
					WannaExit = true;
				}
            }else {
                exitAlpha = 0;
            }
//            Button1.SetPosition(Width()/4, (float)Height()/2.4f);
//            Button2.SetPosition(Width()/4, (float)Height()/2.1f);
            switch(g % 2){
                case 0:
                    Button1.SetPosition(Width()/4, (float)Height()/2.4f);
                    Button2.SetPosition(Width()/4, (float)Height()/2.1f);
                    ExitRectangle = new Rectangle((Width() / 4), (int)((float)Height() / 1.85f), 128, 32);
                    break;
                 case 1:
                     Button1.SetPosition(Width()/2-52, (float)Height()/2.4f);
                     Button2.SetPosition(Width()/2-64, (float)Height()/2.1f);
                     ExitRectangle = new Rectangle((Width() / 2)-48, (int)((float)Height() / 1.85f), 48, 32);
                     break;
            }
			LogoPosition = new Vector2(Width() / 2f - 220, 128);
		}
		public void Draw(SpriteBatch sprBt) {
            Background.Draw(sprBt, new Vector2(Width()/2, Height()/2));
			sprBt.Draw(Logo, new Vector2(LogoPosition.X - 128, LogoPosition.Y), Color.White);
			sprBt.DrawString(Font2, "Virtus Pecto", new Vector2(LogoPosition.X, LogoPosition.Y), Color.White);
			Button1.Draw(sprBt);
			Button2.Draw(sprBt);
            GameBuilder.Builder.DrawRectangle(sprBt, ExitRectangle, new Color(exitAlpha, exitAlpha, exitAlpha, exitAlpha));
			sprBt.DrawString(Font, "Exit", new Vector2(ExitRectangle.X, ExitRectangle.Y), Color.White);
            sprBt.DrawString(Font,Convert.ToString(g%2), new Vector2(0, 0), Color.White);

		}
    }
}
