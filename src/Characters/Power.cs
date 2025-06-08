using System;
using Microsoft.Xna.Framework;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Power{
		public static Power Fireball{get => (Power)fireball.MemberwiseClone();}
		public static Power Lightning{get => (Power)lightning.MemberwiseClone();}
		public static Power Punch{get => (Power)punch.MemberwiseClone();}
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
		private static Power punch = new Power(3, 0, (Vector2 self, Vector2 other, Characters[] entities) => {
			Vector2 position = 32*Motion.VectorSpeed(1, (float)Motion.Angle(self, other))+self - Vector2.One*32;
			for(int i = 0; i < entities.Length; i++){
				if(entities[i] != null && new RectangleF(position, 90.51f).Intersects(entities[i].Hitbox)){
					entities[i].AddHealth(-10);
				}				
			}
			Level1.CreateObject(new Particle(position, 1, 0.5f, 1), ref Level1.Particles);
		});
		private static Power lightning = new Power(2, 3, (Vector2 self, Vector2 other, Characters[] entities) => {
			int target = ObjectBuilder.GetClosest(entities, other);
			entities?[target].AddHealth(-50);
			Level1.CreateObject(new Particle(entities[target].Position, 1, 0.4f, 0), ref Level1.Particles);
		});
		private static Power fireball = new Power(1, 1,(Vector2 self, Vector2 other, Characters[] entities) => {
			Level1.CreateObject(new Fireball(entities, self, -Vector2.Normalize(self-other)*6), ref Level1.Fireballs);
		});
	}
}