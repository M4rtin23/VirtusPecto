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
		public Entity[] Enemy1;
		public Card[] Cards = new Card[3];
		public Entity[] Creature1;
		public Fireball[] Fireballs = [];
		public Particle[] Particles = [];
		public CreationManager CreationManager;
		public static PauseMenu Pause;
		private bool checker;
		public Level(int EnemyQuantity){
			Creature1 = new Entity[]{Player1};
			Enemy1 = new Agent[EnemyQuantity];
			for (int i = 0; i < Enemy1.Length; i++){
				Enemy1[i] = new Agent(CardContent.Enemy, new Vector2(i*400,new Random(i).Next(-500, 500)), Color.Red, ref Creature1, ref Enemy1);
			}
			Cards[0] = new Card(0);
			Cards[1] = new Card(1);
			Cards[2] = new Card(2);
		}
		private void UpdatePausable(){
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
			for(int i = 0; i < Creature1.Length; i++){
				Creature1[i]?.Update();
			}
			if(GlobalGameTime.TotalGameTime.Milliseconds % 1000 == 0){
				ArrayUtils.Fit(ref Fireballs);
			}
			if(ArrayUtils.Count(Enemy1) == 0){
				Environment.Exit(0);
			}
			if(GameMouse.IsClicking){
				CreationManager?.OnCreation();
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
	}
}
