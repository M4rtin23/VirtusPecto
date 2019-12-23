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
			GetMouseState = Mouse.GetState();
			if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Level1.Player1.Position.X,(int) Level1.Player1.Position.Y);
			}
			//Position = new Vector2(GetMouseState.X, GetMouseState.Y);
            Position = Mouse.GetState().Position.ToVector2();
			Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
            if(Game1.Level1 == null){
                IsCreating = false;
            }
			if (IsCreating && IsClicking() && !Game1.IsPaused && Game1.Level1 != null){
				OnCreation(Number);
				IsCreating = false;
			}
		}
		public void OnCreation(int Number){
			if(IsClicking()){
                for(int i = 0; i < 3; i++){
    				if (Number == i && !Mouse1.Hitbox.Intersects(Level1.Cards[i].Hitbox)){
	    				Level1.CreateCreature(Level1.Cards[i].Content, MPosition - new Vector2(0, 32));
                    }
                }
				Number = -1;
			}
		}
	}
}
