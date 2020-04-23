﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Player : GameBuilder.ObjectBuilder{
		public float Health = 100, Mana = 100;
		public CardContent[] Slot;
		private int powerIndex = 1;
		public Player(){
			SpriteIndex = Sprite0;
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
				Slot[i] = CreatureDatabase.GetData(i);
			}
		}
		private void gameControl(){
			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				Level1.CreateFireball(true, Level1.Enemy1[1].Position, 0);
			}
			gameArrow();
			if(IsJoystick){
				gameStick();
			}
			if (IsPressing(4) && PowerButton.CanShoot()) {
				UsePower(powerIndex);
			}
			if (IsPressing(6)) {
				Mouse1.Number = 0;
				Mouse1.IsCreating = true;
			}
			if (IsPressing(7)) {
				Mouse1.Number = 1;
				Mouse1.IsCreating = true;
			}
			if (IsPressing(8)) {
				Mouse1.Number = 2;
				Mouse1.IsCreating = true;
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
			speed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left * (4);
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
			Console.WriteLine(Level1.Particles.Length);
			animationImage(4);
			gameControl();

			Hitbox = new GameBuilder.RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			collision(Level1.Enemy1);
			if(speed == Vector2.Zero){
				imageIndex = 0;
			}
			if(GameBuilder.GameBase.IsInside(Position + speed)){
				base.Update();
			}
		}
		public override void Draw(SpriteBatch batch){
			//Hitbox.Draw(batch);
			//DrawRectangle(batch, Hitbox, Color.White);
			//DrawTriangle(batch, new Vector2(0, 0),new Vector2(500, 0),new Vector2(250,250));
			//DrawRectangle(spriteBatch, Sprite2, Hitbox, Color.White);
//            spriteBatch.DrawString(Font,  ""+GetData(0).Atk , new Vector2(0, 72), Color.White);
			//DrawRectangle(spriteBatch, Sprite2, new Rectangle(Hitbox.Location-(Hitbox.Size.ToVector2()).ToPoint(), (Hitbox.Size.ToVector2()*2).ToPoint()), Color.White);
			//DrawLine(Position-new Vector2(0, Height), GetClosest(Level1.Enemy1, Mouse1.MPosition).Item1, 5,Color.Blue, batch);
//            DrawRectangle(batch, new Rectangle(GetClosest(Level1.Enemy1, Mouse1.MPosition).Item1.ToPoint()-new Point(64), new Point(128)), Color.Blue);
			Vector2 a0 = GetClosest(Level1.Enemy1, Mouse1.MPosition).Item1;
			
			/*DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(-64), new Point(8, 16)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(-64), new Point(16, 8)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(64, -64), new Point(8, 16)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(64-8, -64), new Point(16, 8)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(-64, 48), new Point(8, 16)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(-64, 48+8), new Point(16, 8)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(64, 48), new Point(8, 16)), Color.Blue);
			DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(64-8, 48+8), new Point(16, 8)), Color.Blue);
			*/
			for(int i = 0; i < 8; i++){
				int a = ((i/2) % 2) * 2 -1;
				int b = ((i/4) % 2)*7;
				int c0 = (i % 2) + 1;
				int c1 = ((i+1) % 2) + 1;
				int d = ((i % 4)/3);        
				int e = ((6-i+1) % 2)*(int)Math.Floor((6-i)/4d); 
				Vector2 pos = new Vector2(-a*(float)Math.Cos(MathHelper.ToRadians((GT.TotalGameTime.Milliseconds) % 360))*10,-a*(float)Math.Cos(MathHelper.ToRadians((GT.TotalGameTime.Milliseconds) % 360))*10)+a0;
				if(i < 2 || i > 5){
					pos = new Vector2(-a*(float)Math.Cos(MathHelper.ToRadians((GT.TotalGameTime.Milliseconds) % 360))*10,a*(float)Math.Cos(MathHelper.ToRadians((GT.TotalGameTime.Milliseconds) % 360))*10)+a0;

				}
				DrawRectangle(batch, new Rectangle(pos.ToPoint()+new Point(64*a - 8*d, -64*(b-3)/4-e*8), new Point(8*c0, 8*c1)), Color.Blue);
			}

			stripSprite(4);
			center(4);
			base.Draw(batch);
		}


		public void Lightning(Vector2 pos, Vector2 otherPos, float s, SpriteBatch batch){
			//float s = (float)(CalculateDistance(pos, otherPos))/128;
			s = s/128;
			float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
			batch.Draw(Sprite2, pos, null, Color.White, r, new Vector2(0 ,16), new Vector2(s, 1), SpriteEffects.None, 0);
		}

		public void DrawLine(Vector2 pos, Vector2 otherPos, float size, Color color, SpriteBatch batch){
			float s = (float)(CalculateDistance(pos, otherPos))/128;
			float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
			batch.Draw(Sprite2, pos, null, color, r, new Vector2(0 ,16), new Vector2(s, 1/32f*size), SpriteEffects.None, 0);
		}
		public void UsePower(int powerIndex){
			switch(powerIndex){
				case 1:
				try{
					int target = GetClosest(Level1.Enemy1, Mouse1.MPosition).Item2;
					Level1.Enemy1?[target].AddHealth(-50);
					Level1.CreateParticle(Level1.Enemy1[target].Position, 0.4f, 0);
				}catch{}
					break;
				case 0:
					Level1.CreateFireball(false, Position,(float) CalculateAngle(Position, Game1.Mouse1.MPosition));
					break;
				case 2:
					Vector2 pos = 32*GameBuilder.Motion.VectorSpeed(1, MathHelper.ToRadians((float)CalculateAngle(Position, Mouse1.MPosition)))+Position - Vector2.One*32;
					Level1.CreateParticle(pos, 0.5f, 1);
					break;
			}
		}
		public float Dir(){
			return (float)CalculateDirection(-speed.X, -speed.Y);
		}
		public int GetPowerIndex(){
			return powerIndex;
		}
		
	}
}
