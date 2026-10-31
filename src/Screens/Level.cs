using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;
using System.Collections.Generic;

namespace VirtusPecto.Desktop{
	public class Level : GameBuilder.Screens.Screen{
		public Player Player1 = new Player();
		public ArrayHolder<Entity> Enemy1 = new ArrayHolder<Entity>();
		public Card[] Cards = new Card[3];
		public ArrayHolder<Entity> Creature1 = new ArrayHolder<Entity>();
		public Fireball[] Fireballs = [];
		public Particle[] Particles = [];
		public CreationManager CreationManager;
		public static int MapLimit = 5000;
		public static PauseMenu Pause;
		IEnumerable<IEntity>[] entities;

		public Level(int EnemyQuantity){
			Creature1.Current = new Entity[]{Player1};
			Enemy1.Current = new Agent[EnemyQuantity];
			for (int i = 0; i < Enemy1.Current.Length; i++){
				Enemy1.Current[i] = new Agent(CardContent.Enemy, new Vector2(i*400,new Random(i).Next(-500, 500)), Color.Red, Creature1, Enemy1);
			}
			Cards[0] = new Card(0);
			Cards[1] = new Card(1);
			Cards[2] = new Card(2);
		}
		private void UpdatePausable(){
			InputKeys.Press(5, () => {Pause = new PauseMenu(); Level1.CreationManager = null;});
			entities = [Enemy1.Current, Creature1.Current, Fireballs, Particles, Cards, new IEntity[]{CreationManager}];
			foreach (IEnumerable<IEntity> group in entities){
				foreach (IEntity entity in group){
					entity?.Update();
				}
			}
			if(GlobalGameTime.TotalGameTime.Milliseconds % 1000 == 0){
				ArrayUtils.Fit(ref Fireballs);
			}
			if(ArrayUtils.Count(Enemy1.Current) == 0){
				Environment.Exit(0);
			}
		}
		public override void Update() {
			if(Pause == null){
				UpdatePausable();
			}
			Pause?.Update();
       }
        public void DrawGame(SpriteBatch batch) {
			CreationManager?.Draw(batch.GraphicsDevice);
			batch.Begin(transformMatrix: Camera.LimitedFollow(Player1.Position, Level.MapLimit), samplerState:  SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			entities = [Enemy1.Current, Creature1.Current, Fireballs, Particles, new IEntity[]{CreationManager}];
			foreach (IEnumerable<IEntity> group in entities){
				foreach (IEntity entity in group){
					entity?.Draw(batch);
				}
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
	}
}
