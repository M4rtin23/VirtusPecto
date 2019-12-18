using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public MouseState GetMouseState;
		public Vector2 Position, MPosition;
		public Rectangle Hitbox;
		public bool IsCreating;
		public int Number;

		public GameMouse(){
			GetMouseState = new MouseState();
		}
        public void SetMPosition(Vector2 m){
            MPosition = Position + m;
        }
		public void Update(){
            if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                IsClicking = true;
            }else if(GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && Game1.Joystick != null){
                IsClicking = true;
            }else{
                IsClicking = false;
            }
			GetMouseState = Mouse.GetState();
			if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Levels.Player1.Position.X,(int) Levels.Player1.Position.Y);
			}
			//Position = new Vector2(GetMouseState.X, GetMouseState.Y);
            Position = Mouse.GetState().Position.ToVector2();
			Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
            if(Game1.Levels == null){
                IsCreating = false;
            }
			if (IsCreating &&  IsClicking&& !Game1.IsPaused && Game1.Levels != null){
				OnCreation(Number);
				IsCreating = false;
			}
		}
		public void OnCreation(int Number){
			if ( IsClicking){
                for(int i = 0; i < 3; i++){
    				if (Number == i && !Mouse1.Hitbox.Intersects(Levels.Cards[i].Hitbox)){
	    				Levels.CreateCreature(Levels.Cards[i].Content, MPosition - new Vector2(0, 32));
                    }
                }
				Number = -1;
			}
		}
	}
}
