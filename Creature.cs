using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
	public class Creature : GameBuilder.ObjectBuilder{
		public int CreatureTime = 360;
		private Vector2 Target;
		private float maxSpeed, dist;
		private int targetDefiner = -1, lowestDistance = -1;
        private bool followPlayer;
        int time;

		public Creature(CardContent content,Vector2 pos){
			Hitbox = new Rectangle((int)pos.X,(int) pos.Y,128,128);
			SpriteIndex = content.Sprite;
            maxSpeed = content.Spd;
            dist = content.Dist;
			Position = pos;
			SetTarget();
        }
		public override void Update() {
            if(time - GT.TotalGameTime.Minutes > 4){
                SetTarget();
            }
            Hitbox = new Rectangle((int) Position.X - 64+32, (int) Position.Y - 64, 128-32, 128);
			//CreatureTime--;
			//Standing code.
            // if (CreatureTime == 0){
            //     Levels.Creature1 = null;
            // }
            //Should be updated.
			if (CurrentTarget() > Position.X){
                effect = SpriteEffects.None;
            }else{
                effect = SpriteEffects.FlipHorizontally;
            }
            //Behaviors.
            if(!followPlayer){
		        speed = Follow(Target, Position, 128 + dist, maxSpeed);
                if(speed.X == 0 && speed.Y == 0 && dist > 0 && dist > CalculateDistance(Position, Target)/2 && (GT.TotalGameTime.Milliseconds % 1000 == 0)){
                    Levels.Player1.CreateFireBall(false, Position, (float)CalculateAngle(Position, Target), 0);
                }
                if (targetDefiner != -1){
                    if (Levels.Enemy1[targetDefiner] == null){
                        targetDefiner = -1;
                    }else{
                        //If you compress the array it gets smaller and then when the last element change position it crashes because it doesn't find it.
                        Target = Levels.Enemy1[targetDefiner].Position;
                    }
                }else{
                    SetTarget();
                }
            }else{
                speed = Follow(Levels.Player1.Position, Position, 128, maxSpeed);
                SetTarget();
            }
            if(speed == Vector2.Zero){
                imageIndex = 2;
            }else{
                animationSpeed = 0.125f;                
            }
			animationImage(4);
            base.Update();
		}
        
		public override void Draw(SpriteBatch sprBt) {
            //DrawRectangle(spriteBatch, Sprite2, Hitbox, Color.White);
            stripToSprite(4);
            center(4);
            base.Draw(sprBt);
        }
		public void Follow2(Vector2 Target, Vector2 Position, float hitboxSize){
			if (Target.X - hitboxSize/2 > Position.X){
                speed.X = maxSpeed;
			}
            else
            if (Target.X + hitboxSize/2 < Position.X){
                speed.X = -maxSpeed;
            }else{
                speed.X = 0;
            }
			if (Target.Y - hitboxSize/2 > Position.Y){
                speed.Y = maxSpeed;
            }
            else
            if (Target.Y + hitboxSize/2 < Position.Y){
                speed.Y = -maxSpeed;
			}else{
                speed.Y = 0;
            }
		}
		public void SetTarget(){
			for (int i = 0; i < Levels.Enemy1.Length; i++) {
				//Sees if the Enemy exist.
                if (Levels.Enemy1[i] == null) {
					continue;               
				}
                //Calculate the distance.
				int enemyDistance = (int)CalculateDistance(Levels.Enemy1[i].Position, Position);
				if (lowestDistance == -1) {
					lowestDistance = enemyDistance;               
				}
                //Determine the closest.
				if (enemyDistance <= lowestDistance){
					lowestDistance = enemyDistance;
					targetDefiner = i;
				}
			}
            //Sets the target.
			if (targetDefiner != -1){
                time = GT.TotalGameTime.Minutes;
                Target = Levels.Enemy1[targetDefiner].Position;
                followPlayer = false;
            }else{
                followPlayer = true;
            }
			lowestDistance = -1;
		}
        public float CurrentTarget(){
            float tr = 0;
            switch(followPlayer){
                case false:
                    tr = Target.X;
                    break;
                case true:
                    tr = Levels.Player1.Position.X;
                    break; 
            }
            return tr;
        }
    }
}
