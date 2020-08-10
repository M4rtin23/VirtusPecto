using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public Vector2 Position;
		public Vector2 MPosition{get => Position + MatrixPosition;}
		public bool IsCreating;
		public int Number;
		public bool IsAble;

		public void Update(){
			if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Level1.Player1.Position.X,(int) Level1.Player1.Position.Y);
			}
			Position = Mouse.GetState().Position.ToVector2();
			if(Game1.Level1 == null){
				IsCreating = false;
			}
			if (IsCreating && IsClicking && !Game1.IsPaused && Game1.Level1 != null){
				OnCreation(Number);
			}if(Level1 != null){
				if(Level1.Cards[0].Hitbox.Contains(Position) || Level1.Cards[1].Hitbox.Contains(Position) || Level1.Cards[2].Hitbox.Contains(Position)){
					IsAble = false;
				}else{
					IsAble = true;
				}
				for(int i = 0; i<Level1.Creature1.Length; i++){
					if(Level1.Creature1[i] != null && Level1.Creature1[i].Hitbox.Intersects(new GameBuilder.RectangleF(Mouse1.MPosition-Vector2.One*64, 128))){
						IsAble = false;
						break;
					}else{
						IsAble = true;
					}
				}
			}
		}
		public void OnCreation(int Number){
			if(IsClicking && IsAble){
				for(int i = 0; i < 3; i++){
					if (Number == i && !Level1.Cards[i].Hitbox.Contains(Mouse1.Position)){
						Level1.CreateCreature(Level1.Cards[i].Content, MPosition - new Vector2(0, 32));
					}
				}
				Number = -1;
				IsCreating = false;
			}
		}
	}
}
