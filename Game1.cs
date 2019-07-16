using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static GameMaker.MakerObject;

namespace VirtusPecto.Desktop{
	public class Game1 : Game{
		//System.
        private static GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		public static Color BackGroundColor;
		public static CreatureDatabase GetCreatureDatabase;
		public static GameMouse mouse;
        private static Vector2 matrixPosition;
        public static GameControl Joy;
        public static Matrix Mat;
		public static GameTime GT;

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
        public static bool IsJoy;
        public static bool IsDescriptionOn = true;

        //Rooms.
		public static Lobby StartMenu;
		public static Level Levels;
        public static SettingsMenu Settings;
        public static PauseMenu Pause;

		public Game1(){
			IsPaused = false;
			BackGroundColor = Color.Black;
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
			IsMouseVisible = true;
			mouse = new GameMouse();
			StartMenu = new Lobby();
			CreatureSprite = new Texture2D[6];
	    }

        protected override void Initialize(){
			base.Initialize();
        }
  
        protected override void LoadContent(){
		    spriteBatch = new SpriteBatch(GraphicsDevice);
			Logo = Content.Load<Texture2D>("Logo");
            Sprite0 = Content.Load<Texture2D>("Sprite0");
			Sprite1 = Content.Load<Texture2D>("Sprite1");
			Sprite2 = Content.Load<Texture2D>("Sprite2");
			Sprite3 = Content.Load<Texture2D>("Sprite3");
			Sprite4 = Content.Load<Texture2D>("Sprite4");
            Sprite5 = Content.Load<Texture2D>("Sprite5");
            Back = Content.Load<Texture2D>("BG");
			Font = Content.Load<SpriteFont>("SpriteFontTemPlate");
			Font2 = Content.Load<SpriteFont>("SpriteFont");
			for (int i = 0; i < CreatureSprite.Length; i++){
				CreatureSprite[i] = Content.Load<Texture2D>("Creatures/Creature"+ Convert.ToString(i));
			}
			GetCreatureDatabase = new CreatureDatabase();
		}
  
        protected override void UnloadContent(){
			
		}
        
        protected override void Update(GameTime gameTime){
            GT = gameTime;
            if(LevelNumber == 1){
                Mat = Camera.Follow(Levels.Player1.Position);
            }
            matrixPosition = - new Vector2(Mat.M41, Mat.M42);
            mouse.SetMPosition(matrixPosition);
            if(IsJoy){
                if(Joy == null){
                    Joy = new GameControl();
                }
            }else{
                Joy = null;
            }
            Joy?.Update();
            if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                IsClicking = true;
            }else if(GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && Joy != null){
                IsClicking = true;
            }else{
                IsClicking = false;
            }
			if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)){
				IsPaused = !IsPaused;
                System.Threading.Thread.Sleep(70);
			}
            if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
                IsJoy = true;
            }
            if(WannaExit){
                Exit();
            }
			if (Keyboard.GetState().IsKeyDown(Keys.Enter)) {
				//Window.IsBorderless = true;
				graphics.ApplyChanges();
			}
			if (!IsPaused) {
				Pause = null;
			}
			mouse.Update();
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
        	if (IsPaused) {
				if (Pause == null) {
					Pause = new PauseMenu();
				}
				Pause?.Update();    
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime){
			GraphicsDevice.Clear(BackGroundColor);
            if(LevelNumber == 1){
                Mat = Camera.Follow(Levels.Player1.Position);
                spriteBatch.Begin(transformMatrix: Mat);
                Levels?.Draw(spriteBatch);
                spriteBatch.End();
            }
            spriteBatch.Begin();
            //DrawTriangle(spriteBatch, Sprite2, new Vector2(Width()/2, 0), new Vector2(Width()/4,Height()/2), new Vector2(Width()/4*3,Height()/2));
            //DrawTriangle(spriteBatch, Sprite2, new Vector2(Width()/2, 0), new Vector2(Width()/2-225,Height()/2), new Vector2(Width()/2+225,Height()/2));

            switch(LevelNumber){
				case 0:
	    			StartMenu?.Draw(spriteBatch);
					break;
				case 1:
                    Levels.DrawScreen(spriteBatch);
					//Levels?.Draw();
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

    }
}