using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static GameBuilder.Builder;
using static VirtusPecto.Desktop.CreatureDatabase;

namespace VirtusPecto.Desktop{
	public class Player : GameBuilder.ObjectBuilder{
		public float Health = 100, Mana = 100;
		public CardContent[] Slot;
		public Player(){
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
				Slot[i] = CreatureDatabase.GetData(i);
			}
		}
        private void gameControl(){
            if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				CreateFireBall(true, Levels.Enemy1[1].Position, 0, 0);
			}
            gameArrow();
            if(IsJoystick){
                gameStick();
            }
            if (IsPressing(4) && PowerButton.CanShoot()) {
                usePower();
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
			Hitbox = new Rectangle((int) Position.X - 64 +32, (int) Position.Y - 64, 128-32, 128);
			if(speed == Vector2.Zero){
                imageIndex = 0;
            }
            animationImage(4);
            gameControl();
            base.Update();
        }
		public override void Draw(SpriteBatch sprBt){
            //DrawTriangle(sprBt, new Vector2(0, 0),new Vector2(500, 0),new Vector2(250,250));
            //DrawRectangle(spriteBatch, Sprite2, Hitbox, Color.White);
//            spriteBatch.DrawString(Font,  ""+GetData(0).Atk , new Vector2(0, 72), Color.White);
            //DrawRectangle(spriteBatch, Sprite2, new Rectangle(Hitbox.Location-(Hitbox.Size.ToVector2()).ToPoint(), (Hitbox.Size.ToVector2()*2).ToPoint()), Color.White);
            stripToSprite(4);
            center(4);
            base.Draw(sprBt);
        }
		public void CreateFireBall(bool isEnemy, Vector2 Position, float d, float v){
		//	if(GT.TotalGameTime.Milliseconds % 1000 == 0){
				Array.Resize(ref Levels.Fireballs, Levels.Fireballs.Length+1);
				Levels.Fireballs[Levels.Fireballs.Length-1] = new FireBall(isEnemy, Position, CalculateVectorSpeed(6, d));
                v -= 10;
        //    }
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
			CreateFireBall(false, Position,(float) CalculateAngle(Position, Game1.Mouse1.MPosition), Mana);
        }
        public float Dir(){
            return (float)CalculateDirection(-speed.X, -speed.Y);
        }
    }
}
