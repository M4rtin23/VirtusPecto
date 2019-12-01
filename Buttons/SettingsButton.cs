using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
    public class SettingsButton{
        public Rectangle Hitbox;
        public Vector2 position;
        public Color WordColor;
		bool checker;

        public SettingsButton(int x, int y){
            position = new Vector2(x, y);
            Hitbox = new Rectangle((int)position.X, (int)position.Y, 128, 32);
        }
        public void SetPosition(float x, float y){
            position.X = x;
            position.Y = y;
        }

        public void Collision(){
            Hitbox = new Rectangle((int)position.X, (int)position.Y, 128, 32);            
            if (Hitbox.Intersects(Mouse1.Hitbox)){
                WordColor = Color.Red;
                if(IsClicking){
                    checker = true;
                }
				if (/*Mouse1.GetMouseState.LeftButton == ButtonState.Pressed*/!IsClicking && checker){
                    Settings = new SettingsMenu();
                    IsPaused = false;
                    GoToLevel(2);
					Button1.isActivated = false;
                    checker = false;
                }
            }
            else{
                WordColor = Color.White;
            }
        }
        public void Draw(SpriteBatch sprBt){
            sprBt.DrawString(Font, "Settings", position, WordColor);
        }
    }
}
