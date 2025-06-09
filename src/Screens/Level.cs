using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Level : Screen{
		public Player Player1 = new Player();
		public Enemy[] Enemy1;
		public Card[] Cards = new Card[3];
		public Creature[] Creature1 = [];
		public Fireball[] Fireballs = [];
		public Particle[] Particles = [];
		public CreationManager CreationManager;
		public static PauseMenu Pause;
		private bool checker;
		public Level(int EnemyQuantity){
			Enemy1 = new Enemy[EnemyQuantity];
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i] = new Enemy(new Vector2(i*400,new Random(i).Next(-500, 500)));
			}
		}
		public void Creation() {
			Cards[0] = new Card(0, Color.Red);
			Cards[1] = new Card(1, Color.Green);
			Cards[2] = new Card(2, Color.DarkBlue);
		}
		public override void Update() {
			if(Pause == null){
				InputKeys.Press(5, () => {Pause = new PauseMenu(); Level1.CreationManager = null;}, ref checker);
				for (int i = 0; i < Fireballs.Length; i++) {
					Fireballs[i]?.Update();
				}
				for (int i = 0; i < Particles.Length; i++) {
					Particles[i]?.Update();
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
				if(GlobalGameTime.TotalGameTime.Milliseconds % 1000 == 0){
					Fit(ref Fireballs);
				}
				if(Count(Enemy1) == 0){
					Environment.Exit(0);
				}
				if(GameMouse.IsClicking){
					CreationManager?.OnCreation();
				}
			}
			Pause?.Update();
       }
        public void DrawGame(SpriteBatch batch) {
			CreationManager?.Draw(batch.GraphicsDevice);
			batch.Begin(transformMatrix: Camera.LimitedFollow(Player1.Position), samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			for (int i = 0; i < Fireballs.Length;i++){
				Fireballs[i]?.Draw(batch);
			}
			for (int i = 0; i < Particles.Length; i++) {
				Particles[i]?.Draw(batch);
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
			if (Pause == null){
				CreationManager?.Draw(batch);
			}
			batch.End();
		}
		public override void Draw(SpriteBatch batch){
			ToolBar.Draw(batch);
			for(int i = 0; i < 3; i++){
				Cards[i].Draw(batch);
			}
			Pause?.Draw(batch);
		}
		public void Fit<Type>(ref Type[] obj){
			Type[] a;
			int o = 0;
			//Search Number of non-null elements.
			for(int i = 0;i < obj.Length; i++){
				if(obj[i] != null){
					o++;
				}
			}
			//Set a second array.
			a = new Type[o];
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
			obj = a;
		}
		public void Destroy<Type>(Type[] obj) where Type : class, INullable{
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] != null && !obj[i].GetState()){
					obj[i] = null;
				}
			}
		}
		public int Count<Type>(Type[] obj){
			int result = 0;
			for(int i = 0; i < obj.Length; i++){
				if(obj[i] !=null){
					result++;
				}
			}
			return result;
		}
		public void CreateObject<Type>(Type obj, ref Type[] array){
			Array.Resize(ref array, array.Length+1);
			array[array.Length-1] = obj;
		}
	}
}
