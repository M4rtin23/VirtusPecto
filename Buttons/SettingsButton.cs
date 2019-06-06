using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Lobby;

namespace VirtusPecto.Desktop{
    public class SettingsButton{
        public Rectangle GetCollision;
        public Vector2 position;
        public Color WordColor;
		
        public SettingsButton(int x, int y){
            position = new Vector2(x, y);
            GetCollision = new Rectangle((int)position.X, (int)position.Y, 128, 32);
        }
        public void SetPosition(float x, float y){
            position.X = x;
            position.Y = y;
        }

        public void Collision(){
            GetCollision = new Rectangle((int)position.X, (int)position.Y, 128, 32);            
            if (GetCollision.Intersects(mouse.GetCollision)){
                WordColor = Color.Red;
				if (/*mouse.GetMouseState.LeftButton == ButtonState.Pressed*/IsClicking){
					System.Threading.Thread.Sleep(50);
                    Settings = new SettingsMenu(LevelNumber);
                    IsPaused = false;
                    LevelNumber = 2;
					Button1.isActivated = false;
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
