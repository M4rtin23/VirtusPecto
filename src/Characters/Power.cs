using System;
using Microsoft.Xna.Framework;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Power{
		public static Power Fireball = new Power(1, 1,(Vector2 self, Vector2 other, Characters[] entities) => {Level1.CreateFireball(entities, self, Motion.Angle(self, other));});
		public static Power Lightning = new Power(2, 3, lightning);
		public static Power Punch = new Power(3, 0, punch);
		public readonly int Cost, Index;
		int timer, coolDown = 60;
		Action<Vector2, Vector2, Characters[]> power;
		public float Percentage{get => (coolDown-(float)timer)/coolDown;}
		public bool IsCharged{get => timer <= 0;}

		public Power(int index, int cost, Action<Vector2, Vector2, Characters[]> power){
			Index = index;
			Cost = cost;
			this.power = power;
		}
		public void Update(){
			if(timer > 0){
				timer--;
			}
		}
		public void UsePower(Vector2 self, Vector2 other, Characters[] entities){
			power(self, other, entities);
			timer = coolDown;
		}
		public static Power GetPower(int i){
			if(i == 0){
				return Fireball;
			}
			if(i == 1){
				return Lightning;
			}
			return Punch;
		}
		private static void punch(Vector2 self, Vector2 other, Characters[] entities){
			Vector2 position = 32*Motion.VectorSpeed(1, (float)Motion.Angle(self, other))+self - Vector2.One*32;
			for(int i = 0; i < entities.Length; i++){
				if(entities[i] != null && new RectangleF(position, 90.51f).Intersects(entities[i].Hitbox)){
					entities[i].AddHealth(-10);
				}				
			}
			Level1.CreateParticle(position, 0.5f, 1);
		}
		private static void lightning(Vector2 self, Vector2 other, Characters[] entities){
			int target = ObjectBuilder.GetClosest(entities, other).Item2;
			entities?[target].AddHealth(-50);
			Level1.CreateParticle(entities[target].Position, 0.4f, 0);
		}
	}
}