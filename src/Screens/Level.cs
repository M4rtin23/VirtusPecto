using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Level{
		public BackGround Background;
		public Player Player1;
		public Enemy[] Enemy1;
		public Card[] Cards;
		public Creature[] Creature1 = new Creature[0];
		public ToolBar toolBar;
		public Fireball[] Fireballs;
		public Particle[] Particles;
		private PowerIndicator button;
		private float cardRotation{get => -(Mouse1.Position.Y/Game1.Height-1)*(Mouse1.Position.Y/Game1.Height+1.2f);}
		public Level(int EnemyQuantity){
			button = new PowerIndicator();
			Background = new BackGround(SpriteBackground);
			Fireballs = new Fireball[0];
			Particles = new Particle[0];
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
			if(GT.TotalGameTime.Milliseconds % 1000 == 0){
				FitFireball();
			}
			if(CountEnemies() == 0){
				WannaExit = true;
			}
		}
		public void Draw(SpriteBatch batch) {
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
			if (Mouse1.IsCreating && !Game1.IsPaused) {
				new ObjectBuilder(Cards[Mouse1.Number].Content.Sprite, Mouse1.CardPosition+MatrixPosition-new Vector2(0, 96-100*(cardRotation)+100), new RectangleF(256, 0, 128, 128), new Vector2(64, 64)).Draw(batch);
			}
		}
		public void DrawScreen(SpriteBatch batch){
			toolBar.Draw(batch);
			button.Draw(batch);
			for(int i = 0; i < 3; i++){
				Cards[i].Draw(batch);
			}			
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
		public void DestroyEntities(){
			for(int i = 0; i < Enemy1.Length; i++){
				if(Enemy1[i]?.GetHealth() <= 0){
					Enemy1[i] = null;
				}
			}
			for(int i = 0; i < Creature1.Length; i++){
				if(Creature1[i]?.GetHealth() <= 0){
					Creature1[i] = null;
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
		public void DestroyParticle(){
			for(int i = 0; i < Particles.Length; i++){
				if(Particles[i] != null && !Particles[i].GetState()){
					Particles[i] = null;
				}
			}
			Particle[] a;
			int o = 0;
			//Search Number of non-null elements.
			for(int i = 0;i < Particles.Length; i++){
				if(Particles[i] != null){
					o++;
				}
			}
			//Set a second array.
			a = new Particle[o];
			//Reuses it.
			o = 0;
			//Copies elements for one array to the other.
			for(int i = 0; i < Particles.Length; i++){
				if(Particles[i] != null){
					a[o] = Particles[i];
					o++;
				}
			}
			//Copies the second array to the original.
			Particles = a;
		}
		public void CreateFireball(bool isEnemy, Vector2 Position, float dir){
			Array.Resize(ref Level1.Fireballs, Level1.Fireballs.Length+1);
			Fireballs[Level1.Fireballs.Length-1] = new Fireball(isEnemy, Position, Motion.VectorSpeed(6, dir));
		}
		public int CountEnemies(){
			int result = 0; 
			for(int i = 0; i < Enemy1.Length; i++){
				if(Enemy1[i] !=null){
					result++;
				}
			}
			return result;
		}
		public void CreateCreature(CardContent content, Vector2 pos){
			Array.Resize(ref Level1.Creature1, Level1.Creature1.Length+1);
			Creature1[Level1.Creature1.Length-1] = new Creature(content, pos);
		}
		public void CreateParticle(Vector2 position, float seconds, int type){
			Array.Resize(ref Level1.Particles, Level1.Particles.Length+1);
			Particles[Level1.Particles.Length-1] = new Particle(position, 1, seconds, type);
		}
		public void DrawCard(GraphicsDevice graphicsDevice){
			Vector2[] Vertices = {new Vector2(30*cardRotation, 200*cardRotation), new Vector2(0, SpriteCard.Height), new Vector2(SpriteCard.Width, SpriteCard.Height), new Vector2(SpriteCard.Width-30*cardRotation, 200*cardRotation)};
			Vector2[] OtherVert = {new Vector2(0,0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)};

			VertexPositionColorTexture[] _vertexPositionColors = new VertexPositionColorTexture[8];
			BasicEffect _basicEffect;
			for(int i = 0; i < 8; i++){
				_vertexPositionColors[i] = new VertexPositionColorTexture(new Vector3(Vertices[(i%4)]+Mouse1.CardPosition-new Vector2(64+60, 96+60+150), 0), new Color(79,79,79),OtherVert[i%4]);
			}
			_basicEffect = new BasicEffect(graphicsDevice);
			_basicEffect.Texture = SpriteCard;
			_basicEffect.TextureEnabled = true;
			_basicEffect.VertexColorEnabled = true;
			_basicEffect.World = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
			_basicEffect.CurrentTechnique.Passes[0].Apply();
		    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, _vertexPositionColors, 0, 5);
		}
	}
}
