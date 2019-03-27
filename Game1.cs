using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;

namespace VirtusPecto.Desktop{
	public class Game1 : Game{
		public static GraphicsDeviceManager graphics;
		public static SpriteBatch spriteBatch;
		public static Texture2D Logo;
		public static Texture2D[] Sprite0;
		public static Texture2D   Sprite1;
		public static Texture2D   Sprite2;
		public static Texture2D[] Sprite3;
		public static Texture2D   Sprite4;
		public static Texture2D[] CreatureSprite;

		public static PauseMenu Pause;
        public static SettingsMenu Settings;
		public static GameMouse mouse;
		public static Level Levels;
		public static Lobby StartMenu;
		public static SpriteFont Font, Font2;
		public static Color BackGroundColor;
		public static bool IsPaused;
		public static int LevelNumber;
		public static CreatureDatabase GetCreatureDatabase;
        public static bool WannaExit;
        public static bool IsClicking;
        public static GameControl Joy;
        public static bool IsJoy;
        public static bool IsDescriptionOn = true;

		public Game1(){
			IsPaused = false;
			BackGroundColor = Color.Black;
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            Content.RootDirectory = "Content";
			IsMouseVisible = true;
			mouse = new GameMouse();
			Sprite0 = new Texture2D[4];
			Sprite3 = new Texture2D[2];
			StartMenu = new Lobby();
			CreatureSprite = new Texture2D[3];
	    }

        protected override void Initialize(){
			base.Initialize();
        }
  
        protected override void LoadContent(){
		    spriteBatch = new SpriteBatch(GraphicsDevice);
			Logo = Content.Load<Texture2D>("Logo");
			Sprite_Load(Sprite0, nameof(Sprite0), 4);
			Sprite1 = Content.Load<Texture2D>("Sprite1");
			Sprite2 = Content.Load<Texture2D>("Sprite2");
			Sprite_Load(Sprite3, nameof(Sprite3), 2);
			Sprite4 = Content.Load<Texture2D>("Sprite4");
			Font = Content.Load<SpriteFont>("SpriteFontTemPlate");
			Font2 = Content.Load<SpriteFont>("SpriteFont");
			for (int i = 0; i < 3; i++){
				CreatureSprite[i] = Content.Load<Texture2D>("Creatures/Creature"+ Convert.ToString(i));
			}
			GetCreatureDatabase = new CreatureDatabase();
		}
  
        protected override void UnloadContent(){
			
		}
        
        protected override void Update(GameTime gameTime){
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
                        Levels?.Update(gameTime);
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
			spriteBatch.Begin();
			switch(LevelNumber){
				case 0:
	    			StartMenu?.Draw();
					break;
				case 1:
					Levels?.Draw();
					break;
				case 2:
    				Settings?.Draw();
					break;
			}
			if (IsPaused){
				Pause?.Draw();
			}
			spriteBatch.End();
			base.Draw(gameTime);
        }

		public void Sprite_Load(Texture2D[] loaderSprite,string name,int sprNmb) {
			for (int i = 0; i < sprNmb; i++){
				loaderSprite[i] = Content.Load<Texture2D>(name + "_" + i);
			}
		}
		public static void ToSpriteIndex(Texture2D[] sprite, Texture2D[] spriteIndex,int sprNmb) {
			for (int i = 0; i < sprNmb; i++){
				spriteIndex[i] = sprite[i];
			}
		}
    }
}
