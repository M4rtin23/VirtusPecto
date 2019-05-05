using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public MouseState GetMouseState;
		public Vector2 Position, MPosition;
		public Rectangle GetCollision;
		public bool IsCreating;
		public int number;

		public GameMouse(){
			GetMouseState = new MouseState();
		}
        public void SetMPosition(Vector2 m){
            MPosition = Position + m;
        }
		public void Update(){
			GetMouseState = Mouse.GetState();
			if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Levels.Player1.Position.X,(int) Levels.Player1.Position.Y);
			}
			//Position = new Vector2(GetMouseState.X, GetMouseState.Y);
            Position = Mouse.GetState().Position.ToVector2();
			GetCollision = new Rectangle((int)Position.X, (int)Position.Y, 1, 1);
            if(Game1.Levels == null){
                IsCreating = false;
            }
			if (IsCreating && /*Mouse.GetState().LeftButton == ButtonState.Pressed*/ IsClicking&& !Game1.IsPaused && Game1.Levels != null){
				OnCreation(number);
				IsCreating = false;
			}
		}
		public void OnCreation(int number){
			if (/*Mouse.GetState().LeftButton == ButtonState.Pressed*/ IsClicking){
                for(int i = 0; i < 3; i++){
    				if (number == i && !mouse.GetCollision.Intersects(Levels.Cards[i].GetCollision)){
	    				Levels.Creature1 = new Creature(Levels.Cards[i].Content, MPosition - new Vector2(0, 32));
                    }
                }
				number = -1;
			}
		}
	}
}
