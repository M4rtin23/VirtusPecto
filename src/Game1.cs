﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public partial class Game1 : GameBuilder.GameBase{
		//System.
		private SpriteBatch spriteBatch;
		public static GameMouse Mouse1;
		public static Vector2 MatrixPosition{get => Camera.Position-new Vector2(Width, Height)/2;}
		public static GameControl Joystick;
		public static GameTime GT;
		public static Keys[] TheKeys = {Keys.W, Keys.A, Keys.S, Keys.D, Keys.Space, Keys.Escape, Keys.D1, Keys.D2, Keys.D3};
		public static Buttons[] TheButtons = {Buttons.DPadUp, Buttons.DPadLeft, Buttons.DPadDown, Buttons.DPadRight, Buttons.RightShoulder, Buttons.Start, Buttons.X, Buttons.Y, Buttons.B};

		//Textures.
		public static Texture2D SpriteLogo;
		public static Texture2D SpritePlayer;
		public static Texture2D SpriteCard;
		public static Texture2D SpriteTick;
		public static Texture2D SpritePlacing;
		public static Texture2D SpriteFireball;
		public static Texture2D SpritePowers;
		public static Texture2D[] SpriteCreatures;
		public static Texture2D SpriteBackground;
		public static SpriteFont FontNormal, FontBig;

		//States.
		public static bool IsPaused;
		public static int LevelNumber;
		public static int PreviousLevel;
		public static bool WannaExit;
		public static bool IsJoystick;
		public static bool IsDescriptionOn = true;
		public static bool ShowNearest = false;
		public static bool ShowDirection = false;
		private bool checker;

		//Rooms.
		public static Lobby StartMenu;
		public static Level Level1;
		public static SettingsMenu Settings;
		public static PauseMenu Pause;

		public Game1(){
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1366;
			graphics.PreferredBackBufferHeight = 768;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			Mouse1 = new GameMouse();
			SpriteCreatures = new Texture2D[6];
		}

		protected override void Initialize(){
			base.Initialize();
			StartMenu = new Lobby();
		}
  
		protected override void LoadContent(){
			//GUI.			
			SpriteLogo = Content.Load<Texture2D>("Sprite_Logo");
			SpriteTick = Content.Load<Texture2D>("Sprite_Tick");
			SpritePowers = Content.Load<Texture2D>("Sprite_Powers");
			SpriteCard = Content.Load<Texture2D>("Sprite_Card");
			SpritePlacing = Content.Load<Texture2D>("Sprite_Placing");

			SpriteBackground = Content.Load<Texture2D>("Sprite_Background");

			SpritePlayer = Content.Load<Texture2D>("Sprite_Player");			
			SpriteFireball = Content.Load<Texture2D>("Sprite_Fireball");
			for (int i = 0; i < SpriteCreatures.Length; i++){
				SpriteCreatures[i] = Content.Load<Texture2D>("Creatures/Creature"+ Convert.ToString(i));
			}

			FontNormal = Content.Load<SpriteFont>("Font_Normal");
			FontBig = Content.Load<SpriteFont>("Font_Big");

			spriteBatch = new SpriteBatch(GraphicsDevice);
		}
		protected override void Update(GameTime gameTime){
			GT = gameTime;
			joystick();
			pause();
			Mouse1.Update();

			if(WannaExit){
				Exit();
			}
			switch(LevelNumber){
				case 0:
					StartMenu?.Update();
					IsPaused = false;
					break;
				case 1:
					if(!IsPaused){
						Level1?.Update();
					}
					break;
				case 2:
					Settings?.Update();
					IsPaused = false;
					break;
			}
			
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			GraphicsDevice.Clear(Color.Black);
			Vector2 a;
			if(Level1 == null) a = Vector2.Zero; else a = Level1.Player1.Position;
			spriteBatch.Begin(transformMatrix: Camera.LimitedFollow(a), samplerState:  SamplerState.PointClamp);
			new BackGround(SpriteBackground).Draw(spriteBatch, Camera.Position);
			spriteBatch.End();
			if(LevelNumber == 1){
				if (Mouse1.IsCreating && !Game1.IsPaused) {
					Level1?.DrawCard(GraphicsDevice);
				}
				spriteBatch.Begin(transformMatrix: Camera.LimitedFollow(Level1.Player1.Position), samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
				Level1?.Draw(spriteBatch);
				spriteBatch.End();
			}
			
			spriteBatch.Begin(samplerState:  SamplerState.PointClamp);
			switch(LevelNumber){
				case 0:
					StartMenu?.Draw(spriteBatch);
					break;
				case 1:
					Level1.DrawScreen(spriteBatch);
					break;
				case 2:
					Settings?.Draw(spriteBatch);
					break;
			}
			if (IsPaused){
				Pause?.Draw(spriteBatch);
			}
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}