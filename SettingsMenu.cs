﻿using System;
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
        private Rectangle Back = new Rectangle(0, 0, Sprite3.Width/2, Sprite3.Height);
        private int lastRoom;
        public Vector2 AspectRatio = new Vector2(16f, 9f);
        public SettingsMenu(int ln){
            BackGroundColor = Color.Black;
            lastRoom = ln;
            ShowDescription = new CardDescription();
            SetJoystick = new Joystick(0, 0);
            SetAspectRatio = new AspectBox();
            SetFullscreen = new Fullscreen(0, 0);
            ResolutionBox = new WindowBox();
        }
        public void Update(){
            SetAspectRatio.SetPosition(graphics.PreferredBackBufferWidth / 4 - 64,  graphics.PreferredBackBufferHeight / 2);
            ShowDescription.SetPosition(graphics.PreferredBackBufferWidth * 2/4 - 64,  graphics.PreferredBackBufferHeight / 3 * 2);
            SetFullscreen.SetPosition(graphics.PreferredBackBufferWidth * 3/4 - 64,  graphics.PreferredBackBufferHeight / 2);
            SetJoystick.SetPosition(graphics.PreferredBackBufferWidth * 3/4 - 64,  graphics.PreferredBackBufferHeight / 3 * 2);
            ResolutionBox.SetPosition(graphics.PreferredBackBufferWidth * 2/4 - 64, graphics.PreferredBackBufferHeight / 2);
            ShowDescription.Collision();
            SetAspectRatio.Collision();
            ResolutionBox.Collision();
			SetFullscreen.Collision();
            SetJoystick.Collision();
            if(Back.Intersects(mouse.GetCollision) && /*Mouse.GetState().LeftButton == ButtonState.Pressed*/IsClicking){
                BackGroundColor = Color.DarkGreen;
                LevelNumber = lastRoom;
                Settings = null;
            }
        }
        public void Draw(){
            spriteBatch.Draw(Sprite3, new Vector2(0, 0), Color.White);
            ShowDescription.Draw();
            SetAspectRatio.Draw();
            ResolutionBox.Draw();
			SetFullscreen.Draw();
            SetJoystick.Draw();
        }
    }
}
