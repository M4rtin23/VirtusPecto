using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameBuilder;

namespace VirtusPecto.Desktop{
	public class Game1 : GameBuilder.GameType.FixedView{
		//System.
		private SpriteBatch spriteBatch;
		public static GameMouse Mouse1 = new GameMouse();
		public static Vector2 MatrixPosition{get => GameBuilder.InGame.Camera.Position-new Vector2(Width, Height)/2;}
		public static GameTime GlobalGameTime;
		//Textures.
		public static Dictionary<string, Texture2D> Sprites = new Dictionary<string, Texture2D>();
		public static Texture2D[] SpriteCreatures = new Texture2D[6];
		public static SpriteFont FontNormal, FontBig;
		//States.
		public static bool IsJoystick, IsDescriptionOn = true, ShowNearest = false, ShowDirection = false;
		//Rooms.
		public static Lobby StartMenu = new Lobby();
		public static Level Level1;
		public static SettingsMenu Settings;

		public Game1(){
			graphics = new GraphicsDeviceManager(this);
			Width = 1366;
			Height = 768;
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			Screen = StartMenu;
		}
		protected override void LoadContent(){
			foreach(string element in new string[9]{"Logo", "Tick", "Powers", "Card", "Title", "Background", "Player", "Enemy", "Fireball"}){
				Sprites.Add(element, Content.Load<Texture2D>("Sprite_"+element));
			}
			for (int i = 0; i < SpriteCreatures.Length; i++){
				SpriteCreatures[i] = Content.Load<Texture2D>("Creatures/Creature"+ Convert.ToString(i));
			}
			GameResources.Sprites.Add("Tick", Sprites["Tick"]);
			GameResources.Font = FontNormal = Content.Load<SpriteFont>("Font_Normal");
			FontBig = Content.Load<SpriteFont>("Font_Big");
			spriteBatch = new SpriteBatch(GraphicsDevice);
		}
		protected override void Update(GameTime gameTime){
			GlobalGameTime = gameTime;
			Mouse1.Update();

			Screen.Update();
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime){
			spriteBatch.Begin(transformMatrix: GameBuilder.InGame.Camera.LimitedFollow(Level1?.Player1.Position ?? Vector2.Zero), samplerState:  SamplerState.PointClamp);
			BackGround.Draw(spriteBatch, GameBuilder.InGame.Camera.Position);
			spriteBatch.End();

			Level1?.DrawGame(spriteBatch);

			spriteBatch.Begin(samplerState:  SamplerState.PointClamp);
			Screen.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}