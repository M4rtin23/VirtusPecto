using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public partial class Game1 : GameBuilder.GameType.FixedView{
		//System.
		private SpriteBatch spriteBatch;
		public static GameMouse Mouse1 = new GameMouse();
		public static Vector2 MatrixPosition{get => GameBuilder.InGame.Camera.Position-new Vector2(Width, Height)/2;}
		public static GameTime GT;

		//Textures.
		public static Texture2D SpriteLogo;
		public static Texture2D SpriteTitle;

		public static Texture2D SpritePlayer;
		public static Texture2D SpriteEnemy;

		public static Texture2D SpriteCard;
		public static Texture2D SpriteTick;
		public static Texture2D SpriteFireball;
		public static Texture2D SpritePowers;
		public static Texture2D[] SpriteCreatures = new Texture2D[6];
		public static Texture2D SpriteBackground;
		public static SpriteFont FontNormal, FontBig;

		//States.
		public static bool WannaExit;
		public static bool IsJoystick;
		public static bool IsDescriptionOn = true;
		public static bool ShowNearest = false;
		public static bool ShowDirection = false;

		//Rooms.
		public static Lobby StartMenu = new Lobby();
		public static Level Level1;
		public static SettingsMenu Settings;
		public static PauseMenu Pause;
		public static Screen Screen = StartMenu;

		public Game1(){
			graphics = new GraphicsDeviceManager(this);
			Width = 1366;
			Height = 768;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			//Screen = StartMenu;
		}

		protected override void LoadContent(){
			//GUI.			
			SpriteLogo = Content.Load<Texture2D>("Sprite_Logo");
			SpriteTick = Content.Load<Texture2D>("Sprite_Tick");
			SpritePowers = Content.Load<Texture2D>("Sprite_Powers");
			SpriteCard = Content.Load<Texture2D>("Sprite_Card");
			SpriteTitle = Content.Load<Texture2D>("Sprite_Title");

			SpriteBackground = Content.Load<Texture2D>("Sprite_Background");

			SpritePlayer = Content.Load<Texture2D>("Sprite_Player");
			SpriteEnemy = Content.Load<Texture2D>("Sprite_Enemy");
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
			Pause?.Update();
			Mouse1.Update();

			if(WannaExit){
				Exit();
			}
			if(Pause == null){
				Screen.Update();
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime){
			spriteBatch.Begin(transformMatrix: GameBuilder.InGame.Camera.LimitedFollow(Level1?.Player1.Position ?? Vector2.Zero), samplerState:  SamplerState.PointClamp);
			BackGround.Draw(spriteBatch, GameBuilder.InGame.Camera.Position);
			spriteBatch.End();
			
			if (Pause == null) {
				Level1?.CreationManager?.Draw(GraphicsDevice);
			}

			spriteBatch.Begin(transformMatrix: GameBuilder.InGame.Camera.LimitedFollow(Level1?.Player1.Position ?? Vector2.Zero), samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			Level1?.DrawGame(spriteBatch);
			spriteBatch.End();

			spriteBatch.Begin(samplerState:  SamplerState.PointClamp);
			Pause?.Draw(spriteBatch);
			Screen.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}