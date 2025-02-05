using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class GameMouse{
		public Vector2 Position{get => Mouse.GetState().Position.ToVector2();}
		private Vector2 relativePosition, speed;
		public Vector2 CardPosition{get => Position - new Vector2(relativePosition.X*0.9f, relativePosition.Y/2); set => relativePosition = value;}
		public Vector2 MPosition{get => Position + MatrixPosition;}
		public bool IsCreating;
		public int Number;
		public bool IsAble;
		private bool checker;
		public bool IsInside{get => (Position.Y < Game1.Height-288);}

		public void Update(){
			if(GamePad.GetState(PlayerIndex.One).Buttons.BigButton == ButtonState.Pressed){
				IsJoystick = true;
			}
			if(IsJoystick){
				//This is used for a fixed position of the cursor, just to avoid the cursor moving with the mouse. 
				//Mouse.SetPosition(position.X, position.Y);
				//position += speed;

				//This is for allowing the movement of the cursor with the mouse.
				Mouse.SetPosition((int)Mouse.GetState().X + (int)speed.X,(int)Mouse.GetState().Y + (int)speed.Y);
				speed.X = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X * (Game1.Height/70f);
				speed.Y = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y * (-Game1.Height/70f);
		
			}

			/*if (Keyboard.GetState().IsKeyDown(Keys.Q)){
				Mouse.SetPosition((int)Level1.Player1.Position.X,(int) Level1.Player1.Position.Y);
			}*/
			if(Game1.Level1 == null){
				IsCreating = false;
			}
			if (IsCreating && IsClicking && Pause == null && Game1.Level1 != null){
				OnCreation(Number);
			}if(Level1 != null){
				IsAble = true;
				for(int i = 0; i<Level1.Creature1.Length; i++){
					if(Level1.Creature1[i] != null && Level1.Creature1[i].Hitbox.Intersects(new RectangleF(Mouse1.MPosition-Vector2.One*64, 128))){
						IsAble = false;
						break;
					}else{
						IsAble = true;
					}
				}
			}
		}
		public void OnCreation(int Number){
			if(IsClicking && IsAble && IsInside){
				for(int i = 0; i < 3; i++){
					if (Number == i && !Level1.Cards[i].Hitbox.Contains(Mouse1.Position)){
						Level1.CreateCreature(Level1.Cards[i].Content, CardPosition + MatrixPosition- new Vector2(0, 32+64));
						Level1.Player1.Mana -= Level1.Cards[i].Content.Cost;
					}
				}
				Number = -1;
				IsCreating = false;
			}
		}
		public void Click(Action action){
			if (IsClicking && !checker){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}
		public void Click(RectangleF rectangle, Action action){
			if (IsClicking && !checker && rectangle.Contains(Position)){
				action();
				checker = true;
			}
			if (!IsClicking){
				checker = false;
			}
		}

		public static void Click(Action action, ref bool check){
			if (IsClicking && !check){
				action();
				check = true;
			}
			if (!IsClicking){
				check = false;
			}
		}
	}
}