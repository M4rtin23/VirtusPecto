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
		public Vector2 Position;
        //private Vector2 origin;
        public Texture2D SpriteIndex;
		private float imageIndex;
		private float animationSpeed;
		private SpriteEffects effect;
		private float hspeed, vspeed;
		public Rectangle GetCollision;
		public float Health = 100, Mana = 100;
		public CardContent[] Slot;
		public Player(){
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
//				Slot[i] = CreatureDatabase.Creatures[i];
				Slot[i] = CreatureDatabase.GetData(5-i);
			}
		}
		private void keyboard() {
			animationSpeed = 0;
			if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                usePower();
			}
			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				CreateFireBall(true, Levels.Enemy1[1].Position, 0, 0);
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
                usePower();
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) {
                mouse.Number = 0;
                mouse.IsCreating = true;
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) {
                mouse.Number = 1;
                mouse.IsCreating = true;
			}
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) {
                mouse.Number = 2;
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

		public void Update(){
			GetCollision = new Rectangle((int) Position.X - 64 +32, (int) Position.Y - 64, 128-32, 128);
			imageIndex += animationSpeed;
			Position.X += hspeed;
			Position.Y += vspeed;
            if(IsJoy){
                gameControl();
            }else{
                keyboard();
            }
            if (imageIndex >= 4){
                imageIndex = 0;
				animationSpeed = 0;
            }
        }
        float t = 0;
		public void Draw(SpriteBatch sprBt){
            //DrawRectangle(spriteBatch, Sprite2, GetCollision, Color.White);
//            spriteBatch.DrawString(Font,  ""+GetData(0).Atk , new Vector2(0, 72), Color.White);
            //DrawRectangle(spriteBatch, Sprite2, new Rectangle(GetCollision.Location-(GetCollision.Size.ToVector2()).ToPoint(), (GetCollision.Size.ToVector2()*2).ToPoint()), Color.White);
            sprBt.Draw(SpriteIndex, Position, new Rectangle(128 * (int)imageIndex, 0, 128, 128), Color.White, 0, new Vector2(64, 64), new Vector2(1, 1), effect, 0);
            float x, y;
            t+=0.125f;
            x = Position.X + (float)SqrCos(t)*100;
            y = Position.Y + (float)SqrSin(t)*100;
            sprBt.Draw(Sprite2, new Vector2(x, y), Color.White);
        }
		public void CreateFireBall(bool isEnemy, Vector2 Position, float d, float v){
			if(GT.TotalGameTime.Milliseconds % 1000 == 0){
				Array.Resize(ref Levels.Fireballs, Levels.Fireballs.Length+1);
				Levels.Fireballs[Levels.Fireballs.Length-1] = new FireBall(isEnemy, Position, (float)CalculateHspeed(6, d), (float)CalculateVspeed(6, d));
                v -= 10;
            }
		}
        public void Lightning(Vector2 pos, Vector2 otherPos, float s, SpriteBatch sprBt){
            //float s = (float)(CalculateDistance(pos, otherPos))/128;
            s = s/128;
            float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
            sprBt.Draw(Sprite2, pos, null, Color.White, r, new Vector2(0 ,16), new Vector2(s, 1), SpriteEffects.None, 0);
        }

        public void DrawLine(Vector2 pos, Vector2 otherPos, float size, Color color, SpriteBatch sprBt){
            float s = (float)(CalculateDistance(pos, otherPos))/128;
            float r = (float)(-CalculateAngle(pos, otherPos) * Math.PI/180);
            sprBt.Draw(Sprite2, pos, null, color, r, new Vector2(0 ,16), new Vector2(s, 1/32f*size), SpriteEffects.None, 0);
        }
        private void usePower(){
			CreateFireBall(false, Position,(float) CalculateAngle(Position, Game1.mouse.MPosition), Mana);
        }
    }
}
