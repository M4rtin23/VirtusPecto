using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameMaker.MakerObject;

namespace VirtusPecto.Desktop{
	public class Creature{
		public Vector2 Position;
		public Texture2D SpriteIndex;
		public double ImageIndex, AnimationSpeed;
		public int CreatureTime = 360;
		protected SpriteEffects effect;
		private Vector2 Target;
		private float vspeed, hspeed, maxSpeed, dist;
		private float dir;
		private int targetDefiner = -1, lowestDistance = -1;
        private bool followPlayer;
		public Rectangle Hitbox, r;
        int time;
		//public int hspeed, vspeed;

		public Creature(CardContent content,Vector2 pos){
			Hitbox = new Rectangle((int)pos.X,(int) pos.Y,128,128);
			SpriteIndex = content.Sprite;
            maxSpeed = content.Spd;
            dist = content.Dist;
			Position = pos;
			SetTarget();
        }
		public void Update() {
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
		        Follow(Target, Position, 128 + dist);
                if(hspeed == 0 && vspeed == 0 && dist > 0 && dist > CalculateDistance(Position, Target)/2){
                    Levels.Player1.CreateFireBall(Levels.Gametime, false, Position, (float)CalculateAngle(Position, Target), 0);
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
                Follow(Levels.Player1.Position, Position, 128);
                SetTarget();
            }
            
            if(hspeed != 0 || vspeed != 0){
                AnimationSpeed = 0.125;
            }
			ImageIndex += AnimationSpeed;         
			if (ImageIndex >= 4){
                ImageIndex = 0;
                AnimationSpeed = 0;
            }
            if(hspeed == 0 && vspeed == 0){
                ImageIndex = 2;
            }
            Position.X += hspeed;
	        Position.Y += vspeed;
		}
        
		public void Draw(SpriteBatch sprBt) {
            //DrawRectangle(spriteBatch, Sprite2, Hitbox, Color.White);
            sprBt.Draw(SpriteIndex, Position, new Rectangle((int)ImageIndex*128, 0, 128, 128), Color.White, 0, new Vector2(64, 64), new Vector2(1, 1), effect, 0);
		}
		private void Follow(Vector2 objPosition, Vector2 selfPosition, float hitboxSize){
			AnimationSpeed = 0;
			if(CalculateDistance(selfPosition, objPosition) > hitboxSize && (selfPosition.X != objPosition.X && selfPosition.Y != objPosition.Y)){
            	dir = (float) CalculateAngle(selfPosition, objPosition);
				if(Hitbox.Intersects(Levels.Player1.GetCollision)){
                    dir = dir -90;
                }
                vspeed = (float) CalculateVspeed(maxSpeed, dir);
				hspeed = (float) CalculateHspeed(maxSpeed, dir);
			}else{
				vspeed = 0;
				hspeed = 0;
			}
		}
		public void Follow2(Vector2 Target, Vector2 Position, float hitboxSize){
			if (Target.X - hitboxSize/2 > Position.X){
                hspeed = maxSpeed;
			}
            else
            if (Target.X + hitboxSize/2 < Position.X){
                hspeed = -maxSpeed;
            }else{
                hspeed = 0;
            }
			if (Target.Y - hitboxSize/2 > Position.Y){
                vspeed = maxSpeed;
            }
            else
            if (Target.Y + hitboxSize/2 < Position.Y){
                vspeed = -maxSpeed;
			}else{
                vspeed = 0;
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
