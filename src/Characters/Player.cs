﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.InputKeys;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Player : Characters{
		public float Mana = 50;
		public int Health{get => (int)health;}
		public bool keyCheck = false;
		public CardContent[] Slot;
		public Power Power;
		public Player(){
			powerIndex = 1;
			health = 100;
			SpriteIndex = SpritePlayer;
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
				Slot[i] = CardContent.GetData(i*2);
			}
			Power = Power.GetPower(powerIndex);
		}
		private void gameControl(){
/*			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				Level1.CreateFireball(true, Level1.Enemy1[1].Position, 0);
			}*/
			gameArrow();
			Press(9, ()=>{powerIndex = (powerIndex+1)%3; Power = Power.GetPower(powerIndex);}, ref keyCheck);
			if(IsJoystick){
				gameStick();
			}
			if (IsPressing(4) && Power.IsCharged && Power.Cost <= Mana){
				Power.UsePower(Position, GameMouse.MPosition, Level1.Enemy1);
				Mana -= Power.Cost;
			}
			for(int i = 0; i < 3; i++){
				if (IsPressing(6+i)) {
					if(Level1.Cards[i].Content.Cost <= Mana){
						Level1.CreationManager = new CreationManager(i);
					}
				}
			}
		}
		private void gameArrow() {
			animationSpeed = 0;
			if (IsPressing(2)){
				speed.Y = 4;
				animationSpeed = 0.125f;
			}else if (IsPressing(0)){
				speed.Y = -4;
				animationSpeed = 0.125f;
			}else{
				speed.Y = 0;
			}
			if (IsPressing(3)){
				speed.X = 4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.None;
			}else if (IsPressing(1)){
				speed.X = -4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				speed.X = 0;
			}
		}
		private void gameStick(){
			speed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left * (4)*new Vector2(1, -1);
			if(speed.X != 0 || speed.Y != 0){
				animationSpeed = 0.125f;
			}
			if(speed.X < 0){
				effect = SpriteEffects.FlipHorizontally;
			}else{
				effect = SpriteEffects.None;
			}
		}
		public override void Update(){
			Power.Update();
			animationImage(4);
			gameControl();

			Hitbox = new RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			userCollision(Level1.Enemy1);
			if(speed == Vector2.Zero){
				imageIndex = 0;
			}
			if(GameBuilder.GameType.FixedView.IsInside(Position + speed)){
				base.Update();
			}
			if(health == 0){
				Environment.Exit(0);
			}
		}
		public override void Draw(SpriteBatch batch){
			Vector2 a0 = Level1.Enemy1[GetClosest(Level1.Enemy1, GameMouse.MPosition)].Position;
			if(ShowNearest){
				for(int i = 0; i < 8; i++){
					int a = ((i/2) % 2) * 2 -1;
					int b = ((i/4) % 2)*7;
					int c0 = (i % 2) + 1;
					int c1 = ((i+1) % 2) + 1;
					int d = ((i % 4)/3);
					int e = ((6-i+1) % 2)*(int)Math.Floor((6-i)/4d);
					Vector2 pos = new Vector2(-a*(float)Math.Cos(MathHelper.ToRadians((GlobalGameTime.TotalGameTime.Milliseconds) % 360))*10,-a*(float)Math.Cos(MathHelper.ToRadians((GlobalGameTime.TotalGameTime.Milliseconds) % 360))*10)+a0;
					if(i < 2 || i > 5){
						pos = new Vector2(-a*(float)Math.Cos(MathHelper.ToRadians((GlobalGameTime.TotalGameTime.Milliseconds) % 360))*10,a*(float)Math.Cos(MathHelper.ToRadians((GlobalGameTime.TotalGameTime.Milliseconds) % 360))*10)+a0;

					}
					RectangleF.Draw(batch, pos+new Vector2(64*a - 8*d, -64*(b-3)/4-e*8), new Vector2(8*c0, 8*c1), Color.Blue);
				}
			}
			if(ShowDirection){
				Direction(batch);
			}

			stripSprite(4);
			center(4);
			base.Draw(batch);
		}
		public void Direction(SpriteBatch batch){
			float r = (float)(-Motion.Angle(Position, GameMouse.Position+MatrixPosition));
			Vector2 v = new Vector2((float)Math.Cos(r), (float)Math.Sin(r));
			Line.Draw(batch, Position + v*32, Position + v*64, 6, Color.Red);
		}

	}
}
