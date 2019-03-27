using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class SettingsMenu{
        public WindowBox ResolutionBox;
		public Fullscreen SetFullscreen;
        public AspectBox SetAspectRatio;
        public Joystick SetJoystick;
        public CardDescription ShowDescription;
        private Rectangle Back = new Rectangle(0, 0, Sprite3[1].Width, Sprite3[1].Height);
        private int lastRoom;
        public float AspectRatio = 16/9f;
        public SettingsMenu(int ln){
            lastRoom = ln;
            ShowDescription = new CardDescription(0, 0);
            SetJoystick = new Joystick(0, 0);
            SetAspectRatio = new AspectBox(0, 0);
            SetFullscreen = new Fullscreen(0, 0);
            ResolutionBox = new WindowBox(0, 0);
        }
        public void Update(){
            SetAspectRatio.BoxPosition = new Vector2(graphics.PreferredBackBufferWidth / 4 - 64,  graphics.PreferredBackBufferHeight / 2);
            ShowDescription.Position = new Vector2(graphics.PreferredBackBufferWidth * 2/4 - 64,  graphics.PreferredBackBufferHeight / 3 * 2);
            SetFullscreen.Position = new Vector2(graphics.PreferredBackBufferWidth * 3/4 - 64,  graphics.PreferredBackBufferHeight / 2);
            SetJoystick.Position = new Vector2(graphics.PreferredBackBufferWidth * 3/4 - 64,  graphics.PreferredBackBufferHeight / 3 * 2);
            ResolutionBox.BoxPosition = new Vector2(graphics.PreferredBackBufferWidth * 2/4 - 64, graphics.PreferredBackBufferHeight / 2);
            ShowDescription.Collision();
            SetAspectRatio.Collision();
            ResolutionBox.Collision();
			SetFullscreen.Collision();
            SetJoystick.Update();
            if(Back.Intersects(mouse.GetCollision) && /*Mouse.GetState().LeftButton == ButtonState.Pressed*/IsClicking){
                LevelNumber = lastRoom;
                Settings = null;
            }
        }
        public void Draw(){
            spriteBatch.Draw(Sprite3[1], new Vector2(0, 0), Color.White);
            ShowDescription.Draw();
            SetAspectRatio.Draw();
            ResolutionBox.Draw();
			SetFullscreen.Draw();
            SetJoystick.Draw();
        }
    }
}
