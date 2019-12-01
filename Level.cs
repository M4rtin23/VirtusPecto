using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
    public class Level{
        public BackGround Background;
		public Player Player1;
		public Enemy[] Enemy1;
		public Card[] Cards;
		public Creature Creature1;
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
				Enemy1[i] = new Enemy(i*400,512);
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
			if (Keyboard.GetState().IsKeyDown(Keys.N)) {
	            Enemy1[0] = new Enemy((int)Player1.Position.X,(int) Player1.Position.Y);
            }
			// if(Enemy1.Length >= 3 && Enemy1[2] != null){
            //     Enemy1[2].Position = Mouse1.Position;
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
			Player1.Update();
			Creature1?.Update();
            if(GT.TotalGameTime.Milliseconds % 1000 == 0){
                //FitFireball();
                //FitEnemy();
            }
		}
		public void Draw(SpriteBatch sprBt) {
            Background.Draw(sprBt, Player1.Position);
			for (int i = 0; i < Fireballs.Length;i++){
				if (Fireballs[i] != null){
					Fireballs[i].Draw(sprBt);
				}
			}
			Creature1?.Draw(sprBt);
			Player1.Draw(sprBt);
			for (int i = 0; i < Enemy1.Length; i++){
				if (Enemy1[i] != null){
					Enemy1[i].Draw(sprBt);
				}
			}
		}
        public void DrawScreen(SpriteBatch sprBt){
            button.Draw(sprBt);
            if(Creature1 != null){
                sprBt.DrawString(Font, ""+Creature1.Position, new Vector2(32, 32), Color.White);
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
        public void FitEnemy(){
            Enemy[] a;
            int o = 0;
            //Search Number of non-null elements.
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

	}
}
