﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static GameBuilder.Builder;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Level{
        public BackGround Background;
		public Player Player1;
		public Enemy[] Enemy1;
		public Card[] Cards;
		public Creature[] Creature1 = new Creature[0];
		//public int Difficulty;
		public ToolBar toolBar;
		public FireBall[] Fireballs;
        public GameTime Gametime;
        private PowerButton button;
		public Level(int EnemyQuantity){
            button = new PowerButton();
            Gametime = new GameTime();
            Background = new BackGround(Back);
			Fireballs = new FireBall[0];
			Enemy1 = new Enemy[EnemyQuantity];
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i] = new Enemy(new Vector2(i*400,512));
			}
			toolBar = new ToolBar();
			Player1 = new Player();
            Cards = new Card[3];
		}
		public void Creation() {
			Player1.SpriteIndex = Sprite0;
			Cards[0] = new Card(0, Color.Red);
			Cards[1] = new Card(1, Color.Green);
			Cards[2] = new Card(2, Color.DarkBlue);
		}
		public void Update() {
            button.Update();
			for (int i = 0; i < Fireballs.Length; i++) {
				if (Fireballs[i] != null){
					Fireballs[i].Update();
				}
			}
            for(int i = 0; i < 3; i++){
			    Cards[i].Update();
            }
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i]?.Update();
			}
			Player1.Update();
            for(int i = 0; i < Creature1.Length; i++){
			    Creature1[i]?.Update();
            }
            if(GT.TotalGameTime.Milliseconds % 1000 == 0){
                FitFireball();
                FitEntity();
            }
		}
		public void Draw(SpriteBatch sprBt) {
            Background.Draw(sprBt, Player1.Position);
			for (int i = 0; i < Fireballs.Length;i++){
                Fireballs[i]?.Draw(sprBt);
			}
            for(int i = 0; i < Creature1.Length; i++){
			    Creature1[i]?.Draw(sprBt);
            }
			Player1.Draw(sprBt);
			for (int i = 0; i < Enemy1.Length; i++){
				if (Enemy1[i] != null){
					Enemy1[i].Draw(sprBt);
				}
			}
		}
        public void DrawScreen(SpriteBatch sprBt){
            button.Draw(sprBt);
            if(Creature1.Length > 0 && Creature1[0] != null){
                sprBt.DrawString(Font, ""+Creature1[0].Position, new Vector2(32, 32), Color.White);
                sprBt.DrawString(Font, ""+Creature1.GetHashCode(), new Vector2(32, 64), Color.White);
                sprBt.DrawString(Font, ""+Player1.Position, new Vector2(32, 96), Color.White);
            }
            for(int i = 0; i < 3; i++){
			    Cards[i].Draw(sprBt);
            }
            if (Mouse1.IsCreating && !Game1.IsPaused) {
				sprBt.Draw(Sprite4, Mouse1.Position, new Rectangle(0, 0, 252, 252), Color.White, 0, new Vector2(64+60, 96+60), new Vector2(1, 1), SpriteEffects.None, 0);
				sprBt.Draw(Cards[Mouse1.Number].Content.Sprite, Mouse1.Position, new Rectangle(256, 0, 128, 128), Color.White, 0, new Vector2(64, 96), new Vector2(1, 1), SpriteEffects.None, 0);
			}
            toolBar.Draw(sprBt);
        }
        public void FitFireball(){
            FireBall[] a;
            int o = 0;
            //Search Number of non-null elements.
            for(int i = 0;i < Fireballs.Length; i++){
                if(Fireballs[i] != null){
                    o++;
                }
            }
            //Set a second array.
            a = new FireBall[o];
            //Reuses it.
            o = 0;
            //Copies elements for one array to the other.
            for(int i = 0; i < Fireballs.Length; i++){
                if(Fireballs[i] != null){
                    a[o] = Fireballs[i];
                    o++;
                }
            }
            //Copies the second array to the original.
            Fireballs = a;
        }
        public void FitEntity(){
            Creature[] a;
            int o = 0;
            //Search Number of non-null elements.
            for(int i = 0;i < Creature1.Length; i++){
                if(Creature1[i] != null){
                    o++;
                }
            }
            //Set a second array.
            a = new Creature[o];
            //Reuses it.
            o = 0;
            //Copies elements for one array to the other.
            for(int i = 0; i < Creature1.Length; i++){
                if(Creature1[i] != null){
                    a[o] = Creature1[i];
                    o++;
                }
            }
            //Copies the second array to the original.
            Creature1 = a;
        }
        public void DestroyEnemy(){
            for(int i = 0; i < Enemy1.Length; i++){
                if(Enemy1[i]?.GetHealth() <= 0){
                    Enemy1[i] = null;
                }
            }
        }
        public void DestroyFireball(){
            for(int i = 0; i < Fireballs.Length; i++){
                if(Fireballs[i] != null && !Fireballs[i].GetState()){
                    Fireballs[i] = null;
                }
            }
        }
        public void CreateFireBall(bool isEnemy, Vector2 Position, float d, float v){
            Array.Resize(ref Levels.Fireballs, Levels.Fireballs.Length+1);
            Fireballs[Levels.Fireballs.Length-1] = new FireBall(isEnemy, Position, CalculateVectorSpeed(6, d));
            v -= 10;
		}
        public void CreateCreature(CardContent content, Vector2 pos){
            Array.Resize(ref Levels.Creature1, Levels.Creature1.Length+1);
            Creature1[Levels.Creature1.Length-1] = new Creature(content, pos);
		}
        public Vector2 GetClosest(Entity[] entities, Vector2 pos){
            float shortestDistance = -1;
            int targetDefiner = -1;
			for (int i = 0; i < entities.Length; i++) {
				//Sees if the object indexed exists.
                if (entities[i] == null) {
					continue;               
				}
                //Calculates a distance.
				int enemyDistance = (int)CalculateDistance(entities[i].Position, pos);
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
            if (targetDefiner != -1){
                return entities[targetDefiner].Position;
            }else{
                return new Vector2((float)double.NaN, (float)double.NaN);
            }
        }
	}
}
