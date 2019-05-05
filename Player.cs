using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static GameMaker.MakerObject;
using static VirtusPecto.Desktop.CreatureDatabase;

namespace VirtusPecto.Desktop{
	public class Player{
		private GameTime gt;
		public Vector2 Position;
        //private Vector2 origin;
        public Texture2D SpriteIndex;
		private float imageIndex;
		private float animationSpeed;
		private SpriteEffects effect;
		private float hspeed, vspeed;
		public Rectangle GetCollision;
		public int Health;
		public CardContent[] Slot;
		public Player(){
			gt = new GameTime();
			Health = 100;
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
//				Slot[i] = CreatureDatabase.Creatures[i];
				Slot[i] = CreatureDatabase.GetData(i);
			}
		}
		private void keyboard() {
			animationSpeed = 0;
			if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
				CreateFireBall(gt, false, Position,(float) CalculateAngle(Position, Game1.mouse.MPosition));
                //Levels.Enemy1[0] = new Enemy(100, 100);
			}
			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				CreateFireBall(gt, true, Levels.Enemy1[1].Position, 0);
			}
            if (Keyboard.GetState().IsKeyDown(Keys.S)){
                vspeed = 4;
				animationSpeed = 0.125f;
            }else if (Keyboard.GetState().IsKeyDown(Keys.W)){
                vspeed = -4;
				animationSpeed = 0.125f;
			}else{
				vspeed = 0;
			}	
			if (Keyboard.GetState().IsKeyDown(Keys.D)){
				hspeed = 4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.None;
            }else if (Keyboard.GetState().IsKeyDown(Keys.A)){
				hspeed = -4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				hspeed = 0;
			}
		}
        private void gameControl(){
            //gamePad();
            gameStrick();
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightShoulder == ButtonState.Pressed) {
				CreateFireBall(gt, false, Position,(float) CalculateAngle(Position, Game1.mouse.MPosition));
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
				animationSpeed = 0.125f;
            }else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed){
                vspeed = -4;
				animationSpeed = 0.125f;
			}else{
				vspeed = 0;
			}	
			if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed){
				hspeed = 4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.None;
            }else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed){
				hspeed = -4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				hspeed = 0;
			}
		}
        private void gameStrick(){
            hspeed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X * (4);
            vspeed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y * (-4);
            if(hspeed != 0 || vspeed != 0){
                animationSpeed = 0.125f;
            }
            if(hspeed < 0){
                effect = SpriteEffects.FlipHorizontally;
            }else{
                effect = SpriteEffects.None;
            }
        }

		public void Update(GameTime gameTime){
			gt = gameTime;
			GetCollision = new Rectangle((int) Position.X - 64 +32, (int) Position.Y - 64, 128-32, 128);
			imageIndex += animationSpeed;
			Position.X += hspeed;
			Position.Y += vspeed;
            if(IsJoy){
                gameControl();
            }else{
                keyboard();
            }
            if (imageIndex > 3){
                imageIndex = 0;
				animationSpeed = 0;
            }
        }
		public void Draw(){
            //DrawRectangle(spriteBatch, Sprite2, GetCollision, Color.White);
            spriteBatch.Draw(SpriteIndex, Position, new Rectangle(128 * (int)imageIndex, 0, 128, 128), Color.White, 0, new Vector2(64, 64), new Vector2(1, 1), effect, 0);
//            spriteBatch.DrawString(Font,  ""+GetData(0).Atk , new Vector2(0, 72), Color.White);
		}
		public void CreateFireBall(GameTime gt, bool isEnemy, Vector2 Position, float d){
			if(gt.TotalGameTime.Milliseconds % 1000 == 0){
				Array.Resize(ref Levels.Fireballs, Levels.Fireballs.Length+1);
				Levels.Fireballs[Levels.Fireballs.Length-1] = new FireBall(isEnemy, Position, (float)CalculateHspeed(6, d), (float)CalculateVspeed(6, d));
			}
		}
        public void Lightning(Vector2 pos, Vector2 otherPos, float s){
            //float s = (float)(CalculateDistance(pos, otherPos))/128;
            s = s/128;
            float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
            spriteBatch.Draw(Sprite2, pos, null, Color.White, r, new Vector2(0 ,16), new Vector2(s, 1), SpriteEffects.None, 0);
        }

        public void DrawLine(Vector2 pos, Vector2 otherPos, float size, Color color){
            float s = (float)(CalculateDistance(pos, otherPos))/128;
            float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
            spriteBatch.Draw(Sprite2, pos, null, color, r, new Vector2(0 ,16), new Vector2(s, 1/32f*size), SpriteEffects.None, 0);
        }
    }
}
