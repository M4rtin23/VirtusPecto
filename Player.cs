using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using GameMaker;

namespace VirtusPecto.Desktop{
	public class Player:MakerObject{
		public GameTime gt;
		public Vector2 Position, Origin;
        public Texture2D[] SpriteIndex;
		public double ImageIndex;
		public double AnimationSpeed;
		private SpriteEffects effect;
		public float hspeed, vspeed;
		public Rectangle GetCollision;
		public int Health;
		public CardContent[] Slot;
		private int dir;
        float d;
		public Player(){
			gt = new GameTime();
			Health = 100;
			Position = new Vector2(64, 64);
			SpriteIndex = new Texture2D[4];
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
				Slot[i] = CreatureDatabase.Creatures[i];
			}
		}
		private void keyboard() {
			AnimationSpeed = 0;
			if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
				CreateFireBall(gt, false, Position,(float) CalculateAngle(Position, Game1.mouse.Position));
                //Levels.Enemy1[0] = new Enemy(100, 100);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				CreateFireBall(gt, true, Levels.Enemy1[1].Position, 0);
			}
            if (Keyboard.GetState().IsKeyDown(Keys.S)){
                vspeed = 4;
				AnimationSpeed = 0.125;
            }else if (Keyboard.GetState().IsKeyDown(Keys.W)){
                vspeed = -4;
				AnimationSpeed = 0.125;
			}else{
				vspeed = 0;
			}	
			if (Keyboard.GetState().IsKeyDown(Keys.D)){
				hspeed = 4;
				AnimationSpeed = 0.125;
				effect = SpriteEffects.None;
            }else if (Keyboard.GetState().IsKeyDown(Keys.A)){
				hspeed = -4;
				AnimationSpeed = 0.125;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				hspeed = 0;
			}
		}
        private void gameControl(){
            //gamePad();
            gameStrick();
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed) {
				CreateFireBall(gt, false, Position,(float) CalculateAngle(Position, Game1.mouse.Position));
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) {
                mouse.number = 0;
                mouse.IsCreating = true;
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) {
                mouse.number = 1;
                mouse.IsCreating = true;
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) {
                mouse.number = 2;
                mouse.IsCreating = true;
			}

        }
        private void gamePad() {
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed){
                vspeed = 4;
				AnimationSpeed = 0.125;
            }else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed){
                vspeed = -4;
				AnimationSpeed = 0.125;
			}else{
				vspeed = 0;
			}	
			if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed){
				hspeed = 4;
				AnimationSpeed = 0.125;
				effect = SpriteEffects.None;
            }else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed){
				hspeed = -4;
				AnimationSpeed = 0.125;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				hspeed = 0;
			}
		}
        private void gameStrick(){
            hspeed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * (4);
            vspeed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * (-4);
            if(hspeed != 0 || vspeed != 0){
                AnimationSpeed = 0.125;
            }
            if(hspeed < 0){
                effect = SpriteEffects.FlipHorizontally;
            }else{
                effect = SpriteEffects.None;
            }
        }

		public void Update(GameTime gameTime){
            if(hspeed != 0 || vspeed != 0){
                d = (float)(CalculateDirection(-hspeed, -vspeed));
            }else{
                d = 0;
            }
			gt = gameTime;
			Origin = new Vector2(SpriteIndex[(int) ImageIndex].Width / 2, SpriteIndex[(int)ImageIndex].Height / 2);
			GetCollision = new Rectangle((int) Position.X - (int)Origin.X, (int) Position.Y-(int)Origin.Y, SpriteIndex[(int) ImageIndex].Width, SpriteIndex[(int)ImageIndex].Height);
			ImageIndex += AnimationSpeed;
			Position.X += hspeed;
			Position.Y += vspeed;
            if(IsJoy){
                gameControl();
            }else{
                keyboard();
            }
            if (ImageIndex > 3){
                ImageIndex = 0;
				AnimationSpeed = 0;
            }
        }
		public void Draw() { 
            spriteBatch.Draw(SpriteIndex[Convert.ToInt16(ImageIndex)],Position, new Rectangle(0, 0, 128, 128), Color.White, 0, Origin, new Vector2(1, 1), effect, 1f/Position.Y);
			spriteBatch.DrawString(Font, Convert.ToString(Convert.ToDouble(gt.TotalGameTime.Milliseconds)), new Vector2(0, 160), Color.White);
			dir = (int)CalculateAngle(Position, mouse.Position);
			spriteBatch.DrawString(Font, Convert.ToString(dir), new Vector2(0, 64), Color.White);
			spriteBatch.DrawString(Font, Convert.ToString(CalculateDistance(Position, mouse.Position)), new Vector2(0, 128), Color.White);
			spriteBatch.DrawString(Font, Convert.ToString(CalculateVspeed(3, dir)), new Vector2(128, 64), Color.White);
			spriteBatch.DrawString(Font, Convert.ToString(CalculateHspeed(3, dir)), new Vector2(128, 128), Color.White);
			spriteBatch.DrawString(Font, Convert.ToString(d), new Vector2(128, 196), Color.White);
		}
		public void CreateFireBall(GameTime gt, bool isEnemy, Vector2 Position, float d){
			if(gt.TotalGameTime.Milliseconds % 1000 == 0){
				Array.Resize(ref Levels.Fireballs, Levels.Fireballs.Length+1);
				Levels.Fireballs[Levels.Fireballs.Length-1] = new FireBall(isEnemy, Position, (float)CalculateHspeed(6, d), (float)CalculateVspeed(6, d));
			}
		}
    }
}
