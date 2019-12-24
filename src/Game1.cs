using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VirtusPecto.Desktop{
	public partial class Game1 : GameBuilder.Game1{
		//System.
        private static GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		public static CreatureDatabase GetCreatureDatabase;
		public static GameMouse Mouse1;
        private static Vector2 matrixPosition;
        public static GameControl Joystick;
        public static Matrix Mat;
		public static GameTime GT;
        public static Keys[] TheKeys = {Keys.W, Keys.A, Keys.S, Keys.D, Keys.Space, Keys.Escape, Keys.D1, Keys.D2, Keys.D3};
        public static Buttons[] TheButtons = {Buttons.DPadUp, Buttons.DPadLeft, Buttons.DPadDown, Buttons.DPadRight, Buttons.RightShoulder, Buttons.Start, Buttons.X, Buttons.Y, Buttons.B};

        //Textures.
		public static Texture2D Logo;
		public static Texture2D Sprite0;
		public static Texture2D Sprite1;
		public static Texture2D Sprite2;
		public static Texture2D Sprite3;
		public static Texture2D Sprite4;
        public static Texture2D Sprite5;
        public static Texture2D Menu;
        public static Texture2D Power;
		public static Texture2D[] CreatureSprite;
        public static Texture2D Back;
		public static SpriteFont Font, Font2;

        //States.
		public static bool IsPaused;
		public static int LevelNumber;
        public static int PreviousLevel;
        public static bool WannaExit;
        public static bool IsJoystick;
        public static bool IsDescriptionOn = true;
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
			CreatureSprite = new Texture2D[6];
	    }

        protected override void Initialize(){
			base.Initialize();
            StartMenu = new Lobby();
        }
  
        protected override void LoadContent(){
            base.LoadContent();
            Back = Content.Load<Texture2D>("BG");
            spriteBatch = new SpriteBatch(GraphicsDevice);
			Logo = Content.Load<Texture2D>("Logo");
            Sprite0 = Content.Load<Texture2D>("Sprite0");
			Sprite1 = Content.Load<Texture2D>("Sprite1");
			Sprite2 = Content.Load<Texture2D>("Sprite2");
			Sprite3 = Content.Load<Texture2D>("Sprite3");
			Sprite4 = Content.Load<Texture2D>("Sprite4");
            Sprite5 = Content.Load<Texture2D>("Sprite5");
            Menu = Content.Load<Texture2D>("menu0");
            Power = Content.Load<Texture2D>("Power");
			Font = Content.Load<SpriteFont>("SpriteFontTemPlate");
			Font2 = Content.Load<SpriteFont>("SpriteFont");
			for (int i = 0; i < CreatureSprite.Length; i++){
				CreatureSprite[i] = Content.Load<Texture2D>("Creatures/Creature"+ Convert.ToString(i));
			}
			GetCreatureDatabase = new CreatureDatabase();
		}
        protected override void Update(GameTime gameTime){
            GT = gameTime;
            matrix();
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
            if(LevelNumber == 1){
                Mat = Camera.Follow(Level1.Player1.Position);
                spriteBatch.Begin(transformMatrix: Mat, samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
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