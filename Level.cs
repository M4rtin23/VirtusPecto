using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Level{
		public Player Player1;
		public Enemy[] Enemy1;
		public Card[] Cards;
		public Creature Creature1;
		//public int Difficulty;
		public ToolBar toolBar;
		public FireBall[] Fireballs;
        public GameTime Gametime;
		public Level(int EnemyQuantity){
			Fireballs = new FireBall[0];
			Enemy1 = new Enemy[EnemyQuantity];
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i] = new Enemy(i*400,512);
			}
			toolBar = new ToolBar();
			Player1 = new Player();
			BackGroundColor = Color.DarkGreen;
            Cards = new Card[3];
		}
		public void Creation() {
			ToSpriteIndex(Sprite0, Player1.SpriteIndex,4);
			Cards[0] = new Card(0, Color.Red);
			Cards[1] = new Card(1, Color.Green);
			Cards[2] = new Card(2, Color.DarkBlue);
		}
		public void Update(GameTime gameTime) {
            Gametime = gameTime;
			// if(Enemy1.Length >= 3 && Enemy1[2] != null){
            //     Enemy1[2].Position = mouse.Position;
            // }
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
			Player1.Update(gameTime);
			Creature1?.Update();
            if(gameTime.TotalGameTime.Milliseconds % 900 == 0){
                FitFireball();
                //FitEnemy();
            }
		}
		public void Draw() {
            spriteBatch.DrawString(Font, Convert.ToString(Enemy1.Length), new Vector2(0, 256), Color.White);
            //spriteBatch.DrawString(Font, Convert.ToString(Enemy1[2].GetHashCode()), new Vector2(0, 224), Color.White);
			for (int i = 0; i < Fireballs.Length;i++){
				if (Fireballs[i] != null){
					Fireballs[i].Draw();
				}
			}
			Creature1?.Draw();
			Player1.Draw();
			for (int i = 0; i < Enemy1.Length; i++){
				if (Enemy1[i] != null){
					Enemy1[i].Draw();
				}
			}
            for(int i = 0; i < 3; i++){
			    Cards[i].Draw();
            }
			if (mouse.IsCreating && !Game1.IsPaused) {
				spriteBatch.Draw(Sprite4, mouse.Position, new Rectangle(0, 0, 252, 252), Color.White, 0, new Vector2(64+60, 96+60), new Vector2(1, 1), SpriteEffects.None, 0);
				spriteBatch.Draw(Cards[mouse.number].Content.Sprite, mouse.Position, new Rectangle(256, 0, 128, 128), Color.White, 0, new Vector2(64, 96), new Vector2(1, 1), SpriteEffects.None, 0);
			}
            toolBar.Draw();

		}
        public void FitFireball(){
            FireBall[] a;
            int o = 0;
            //Search number of non-null elements.
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
        public void FitEnemy(){
            Enemy[] a;
            int o = 0;
            //Search number of non-null elements.
            for(int i = 0;i < Enemy1.Length; i++){
                if(Enemy1[i] != null){
                    o++;
                }
            }
            //Set a second array.
            a = new Enemy[o];
            //Reuses it.
            o = 0;
            //Copies elements for one array to the other.
            for(int i = 0; i < Enemy1.Length; i++){
                if(Enemy1[i] != null){
                    a[o] = Enemy1[i];
                    o++;
                }
            }
            //Copies the second array to the original.
            Enemy1 = a;
        }
	}
}
