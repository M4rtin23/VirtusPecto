using System;
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
		public ToolBar toolBar;
		public Fireball[] Fireballs;
		private PowerButton button;
		public Level(int EnemyQuantity){
			button = new PowerButton();
			Background = new BackGround(Back);
			Fireballs = new Fireball[0];
			Enemy1 = new Enemy[EnemyQuantity];
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i] = new Enemy(new Vector2(i*400,new Random(i).Next(-500, 500)));
			}
			toolBar = new ToolBar();
			Player1 = new Player();
			Cards = new Card[3];
		}
		public void Creation() {
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
				//FitEntity();
			}
		}
		public void Draw(SpriteBatch batch) {
			Background.Draw(batch, Player1.Position);
			for (int i = 0; i < Fireballs.Length;i++){
				Fireballs[i]?.Draw(batch);
			}
			for(int i = 0; i < Creature1.Length; i++){
				Creature1[i]?.Draw(batch);
			}
			Player1.Draw(batch);
			for (int i = 0; i < Enemy1.Length; i++){
				if (Enemy1[i] != null){
					Enemy1[i].Draw(batch);
				}
			}
		}
		public void DrawScreen(SpriteBatch batch){
			button.Draw(batch);
			if(Creature1.Length > 0 && Creature1[0] != null){
				batch.DrawString(Font, ""+Creature1[0].Position, new Vector2(32, 32), Color.White);
				batch.DrawString(Font, ""+Creature1.GetHashCode(), new Vector2(32, 64), Color.White);
				batch.DrawString(Font, ""+Player1.Position, new Vector2(32, 96), Color.White);
			}
			for(int i = 0; i < 3; i++){
				Cards[i].Draw(batch);
			}
			if (Mouse1.IsCreating && !Game1.IsPaused) {
				batch.Draw(Sprite4, Mouse1.Position, new Rectangle(0, 0, 252, 252), Color.White, 0, new Vector2(64+60, 96+60), new Vector2(1, 1), SpriteEffects.None, 0);
				batch.Draw(Cards[Mouse1.Number].Content.Sprite, Mouse1.Position, new Rectangle(256, 0, 128, 128), Color.White, 0, new Vector2(64, 96), new Vector2(1, 1), SpriteEffects.None, 0);
			}
			toolBar.Draw(batch);
		}
		public void FitFireball(){
			Fireball[] a;
			int o = 0;
			//Search Number of non-null elements.
			for(int i = 0;i < Fireballs.Length; i++){
				if(Fireballs[i] != null){
					o++;
				}
			}
			//Set a second array.
			a = new Fireball[o];
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
		public object Fit(object[] obj){
			object[] a;
			int o = 0;
			//Search Number of non-null elements.
			for(int i = 0;i < obj.Length; i++){
				if(obj[i] != null){
					o++;
				}
			}
			//Set a second array.
			a = new object[o];
			//Reuses it.
			o = 0;
			//Copies elements for one array to the other.
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] != null){
					a[o] = obj[i];
					o++;
				}
			}
			//Copies the second array to the original.
			return a;
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
		public void CreateFireball(bool isEnemy, Vector2 Position, float dir){
			Array.Resize(ref Level1.Fireballs, Level1.Fireballs.Length+1);
			Fireballs[Level1.Fireballs.Length-1] = new Fireball(isEnemy, Position, CalculateVectorSpeed(6, dir));
		}
		public void CreateCreature(CardContent content, Vector2 pos){
			Array.Resize(ref Level1.Creature1, Level1.Creature1.Length+1);
			Creature1[Level1.Creature1.Length-1] = new Creature(content, pos);
		}
	}
}
