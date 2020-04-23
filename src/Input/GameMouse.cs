using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		//public MouseState GetMouseState;
		public Vector2 Position;
		public Vector2 MPosition{get => Position + MatrixPosition;}
		//public Rectangle Hitbox;
		public bool IsCreating;
		public int Number;
		public bool IsAble;

		public void Update(){
			if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Level1.Player1.Position.X,(int) Level1.Player1.Position.Y);
			}
			//Position = new Vector2(GetMouseState.X, GetMouseState.Y);
			Position = Mouse.GetState().Position.ToVector2();
			if(Game1.Level1 == null){
				IsCreating = false;
			}
			if (IsCreating && IsClicking && !Game1.IsPaused && Game1.Level1 != null){
				OnCreation(Number);
				IsCreating = false;
			}if(Level1 != null){
			if(Level1.Cards[0].Hitbox.Contains(Position) || Level1.Cards[1].Hitbox.Contains(Position) || Level1.Cards[2].Hitbox.Contains(Position)){
				IsAble = false;
			}else{
				IsAble = true;
			}}
		}
		public void OnCreation(int Number){
			if(IsClicking && IsAble){
				for(int i = 0; i < 3; i++){
					if (Number == i && !Level1.Cards[i].Hitbox.Contains(Mouse1.Position)){
						Level1.CreateCreature(Level1.Cards[i].Content, MPosition - new Vector2(0, 32));
					}
				}
				Number = -1;
			}
		}
	}
}
