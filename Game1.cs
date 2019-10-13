using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Game1 : GameBuilder.Game1{
		//System.
        private static GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		public static CreatureDatabase GetCreatureDatabase;
		public static GameMouse mouse;
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
		public static Texture2D[] CreatureSprite;
        public static Texture2D Back;
		public static SpriteFont Font, Font2;

        //States.
		public static bool IsPaused;
		public static int LevelNumber;
        public static bool WannaExit;
        public static bool IsClicking;
        public static bool IsJoystick;
        public static bool IsDescriptionOn = true;
        bool checker;

        //Rooms.
		public static Lobby StartMenu;
		public static Level Levels;
        public static SettingsMenu Settings;
        public static PauseMenu Pause;

		public Game1(){
			IsPaused = false;
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
			IsMouseVisible = true;
			mouse = new GameMouse();
			CreatureSprite = new Texture2D[6];
	    }

        protected override void Initialize(){
			base.Initialize();
            StartMenu = new Lobby();

        }
  
        protected override void LoadContent(){
            Back = Content.Load<Texture2D>("BG");
            spriteBatch = new SpriteBatch(GraphicsDevice);
			Logo = Content.Load<Texture2D>("Logo");
            Sprite0 = Content.Load<Texture2D>("Sprite0");
			Sprite1 = Content.Load<Texture2D>("Sprite1");
			Sprite2 = Content.Load<Texture2D>("Sprite2");
			Sprite3 = Content.Load<Texture2D>("Sprite3");
			Sprite4 = Content.Load<Texture2D>("Sprite4");
            Sprite5 = Content.Load<Texture2D>("Sprite5");
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
            mouse.Update();

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
                        Levels?.Update();
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
                Mat = Camera.Follow(Levels.Player1.Position);
                spriteBatch.Begin(transformMatrix: Mat);
                Levels?.Draw(spriteBatch);
                spriteBatch.End();
            }

            spriteBatch.Begin();
            switch(LevelNumber){
				case 0:
	    			StartMenu?.Draw(spriteBatch);
					break;
				case 1:
                    Levels.DrawScreen(spriteBatch);
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
        
        public static Vector2 GetMatrix(){
            return matrixPosition;
        }
        public static int Width(){
            return graphics.PreferredBackBufferWidth;
        }
        public static int Height(){
            return graphics.PreferredBackBufferHeight;
        }
        public static bool IsFullScreen(){
            return graphics.IsFullScreen;
        }
        public static void SetWindowSize(Vector2 size){
            graphics.PreferredBackBufferWidth = (int)size.X;
            graphics.PreferredBackBufferHeight = (int)size.Y;
            graphics.ApplyChanges();
        }
        public static void Fullscreen(bool state){
            graphics.IsFullScreen = state;
	    	graphics.ApplyChanges();
        }
        public static bool IsPressing(int index){
            if(!IsJoystick){
                return Keyboard.GetState().IsKeyDown(TheKeys[index]);
            }else{
                return GamePad.GetState(PlayerIndex.One).IsButtonDown(TheButtons[index]);
            }
        }
        private void joystick(){
            if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
                IsJoystick = true;
            }
            if(IsJoystick){
                if(Joystick == null){
                    Joystick = new GameControl();
                }
            }else{
                Joystick = null;
            }
            Joystick?.Update();
        }
        private void pause(){
            if (IsPressing(5)){
                checker = true;
			}
			if (!IsPressing(5) && checker){
				IsPaused = !IsPaused;
                checker = false;
			}
            if (!IsPaused) {
				Pause = null;
			}
            if (IsPaused) {
				if (Pause == null) {
					Pause = new PauseMenu();
				}
				Pause?.Update();    
            }
        }
        private void matrix(){
            if(LevelNumber == 1){
                Mat = Camera.Follow(Levels.Player1.Position);
            }
            matrixPosition = - new Vector2(Mat.M41, Mat.M42);
            mouse.SetMPosition(matrixPosition);
        }
    }
}