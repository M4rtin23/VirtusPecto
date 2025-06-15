using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.InputKeys;
using GameBuilder;
using GameBuilder.InGame;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Player : Entity{
		public float Mana = 50;
		public int Health{get => (int)health;}
		public bool keyCheck = false;
		public CardContent[] Slot;
		public Power Power;
		public Player(){
			powerIndex = 1;
			health = 100;
			SpriteIndex = SpritePlayer;
			Position = new Vector2(64, 64);
			Slot = new CardContent[3];
			for(int i = 0; i < 3; i++){
				Slot[i] = CardContent.GetData(i*2);
			}
			Power = Power.GetPower(powerIndex);
		}
		private void gameControl(){
/*			if (Keyboard.GetState().IsKeyDown(Keys.L)) {
				Level1.CreateFireball(true, Level1.Enemy1[1].Position, 0);
			}*/
			gameArrow();
			Press(9, ()=>{powerIndex = (powerIndex+1)%3; Power = Power.GetPower(powerIndex);}, ref keyCheck);
			if(IsJoystick){
				gameStick();
			}
			if (IsPressing(4) && Power.IsCharged && Power.Cost <= Mana){
				Power.UsePower(Position, GameMouse.MPosition, Level1.Enemy1);
				Mana -= Power.Cost;
			}
			for(int i = 0; i < 3; i++){
				if (IsPressing(6+i)) {
					if(Level1.Cards[i].Content.Cost <= Mana){
						Level1.CreationManager = new CreationManager(i);
					}
				}
			}
		}
		private void gameArrow() {
			animationSpeed = 0;
			if (IsPressing(2)){
				speed.Y = 4;
				animationSpeed = 0.125f;
			}else if (IsPressing(0)){
				speed.Y = -4;
				animationSpeed = 0.125f;
			}else{
				speed.Y = 0;
			}
			if (IsPressing(3)){
				speed.X = 4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.None;
			}else if (IsPressing(1)){
				speed.X = -4;
				animationSpeed = 0.125f;
				effect = SpriteEffects.FlipHorizontally;
			}else{
				speed.X = 0;
			}
		}
		private void gameStick(){
			speed = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left * (4)*new Vector2(1, -1);
			if(speed.X != 0 || speed.Y != 0){
				animationSpeed = 0.125f;
			}
			if(speed.X < 0){
				effect = SpriteEffects.FlipHorizontally;
			}else{
				effect = SpriteEffects.None;
			}
		}
		public override void Update(){
			Power.Update();
			animationImage(4);
			gameControl();

			Hitbox = new RectangleF((int) Position.X - 32, (int) Position.Y + 32, 128-64, 32);
			userCollision(Level1.Enemy1);
			if(speed == Vector2.Zero){
				imageIndex = 0;
			}
			if(GameBuilder.GameType.FixedView.IsInside(Position + speed)){
				base.Update();
			}
			if(health == 0){
				Environment.Exit(0);
			}
		}
		public override void Draw(SpriteBatch batch){
			if(ShowNearest){
				SelectionBox(Level1.Enemy1[GetClosest(Level1.Enemy1, GameMouse.MPosition)].Position, batch);
			}
			if(ShowDirection){
				Direction(Position, GameMouse.Position+MatrixPosition, batch);
			}

			stripSprite(4);
			center(4);
			base.Draw(batch);
		}
		public static void Direction(Vector2 self, Vector2 other, SpriteBatch batch){
			Vector2 v = (other-self)/(other-self).Length();
			Line.Draw(batch, self + v*32, self + v*64, 6, Color.Red);
		}
		public static void SelectionBox(Vector2 position, SpriteBatch batch){
			int trace = 10, thickness = 8, size = 24;
			float trajectory = (float)Math.Cos(MathHelper.ToRadians(GlobalGameTime.TotalGameTime.Milliseconds) % 360);
			Texture2D texture = new Texture2D(batch.GraphicsDevice, 2, 2);
			texture.SetData(new Color[]{Color.White, Color.White, Color.White, new Color(0,0,0,0)});

			batch.Draw(texture, position + Vector2.One*trajectory*trace-Vector2.One*size, null, Color.Blue, 0, new Vector2(1,1), thickness, SpriteEffects.None, 0);
			batch.Draw(texture, position + new Vector2(1,-1)*trajectory*trace-new Vector2(1,-1)*size, null, Color.Blue, (float)-Math.PI/2, new Vector2(1,1), thickness, SpriteEffects.None, 0);
			batch.Draw(texture, position - new Vector2(1,-1)*trajectory*trace+new Vector2(1,-1)*size, null, Color.Blue, (float)Math.PI/2, new Vector2(1, 2), thickness, SpriteEffects.None, 0);
			batch.Draw(texture, position - Vector2.One*trajectory*trace+Vector2.One*size, null, Color.Blue, (float)Math.PI, new Vector2(2, 1), thickness, SpriteEffects.None, 0);
		}

	}
}
