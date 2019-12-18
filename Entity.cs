using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
    public class Entity : GameBuilder.ObjectBuilder{
        protected Vector2 target, startingPoint;
        protected int health = 100;
        protected float maxSpeed, dist;
		protected int targetDefiner = -1, shortestDistance = -1;
        protected bool followPlayer;
        protected int time;

        public override void Draw(SpriteBatch sprBt) {
            //DrawRectangle(spriteBatch, Sprite2, Hitbox, Color.White);
            center(4);
            stripToSprite(4);
            base.Draw(sprBt);
            if(health < 100){
                sprBt.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(64, 64, 64, 128), 0, new Vector2(0, 0), new Vector2(1, 1/4f), SpriteEffects.None, 0);
                sprBt.Draw(Sprite2, Position - new Vector2(64, 80), null, new Color(255, 0, 0, 128), 0, new Vector2(0, 0), new Vector2((float)health/100, 1/4f), SpriteEffects.None, 0);
            }
        }
		public void SetTarget(Entity[] entities){
			for (int i = 0; i < entities.Length; i++) {
				//Sees if the Enemy exist.
                if (entities[i] == null) {
					continue;               
				}
                //Calculates a distance.
				int enemyDistance = (int)CalculateDistance(entities[i].Position, Position);
                //Compares  
				if (shortestDistance == -1) {
					shortestDistance = enemyDistance;               
				}
                //Determines the closest.
				if (enemyDistance <= shortestDistance){
					shortestDistance = enemyDistance;
					targetDefiner = i;
				}
			}
            //Sets the target.
			if (targetDefiner != -1){
                time = GT.TotalGameTime.Minutes;
                target = entities[targetDefiner].Position;
                followPlayer = false;
            }else{
                followPlayer = true;
            }
			shortestDistance = -1;
		}
        protected void lookAtTarget(){
            if (CurrentTarget() > Position.X){
                effect = SpriteEffects.None;
            }else{
                effect = SpriteEffects.FlipHorizontally;
            }
        }
        public void CheckTarget(Entity[] entities){
            if (targetDefiner != -1){
                if (entities[targetDefiner] == null){
                    targetDefiner = -1;
                }else{
                    target = entities[targetDefiner].Position;
                }
            }else{
                SetTarget(entities);
            }
        }
        public float CurrentTarget(){
            float tr = 0;
            if(followPlayer){
                tr = startingPoint.X;
            }else{
                tr = target.X;
            }
            return tr;
        }
        protected void followTarget(){
            speed = Follow(target, Position, 64 + dist, maxSpeed);
        }  
        public void AddHealth(int number){
            health += number;
        }
        public int GetHealth(){
            return health;
        }
        public Vector2 GetStartingPoint(){
            return startingPoint;
        }
    }
}
