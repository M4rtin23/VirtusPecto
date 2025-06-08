using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class CreationManager{
        private Vector2 relativePosition;
        public Vector2 CardPosition{get => GameMouse.Position - new Vector2(relativePosition.X*0.9f, relativePosition.Y/2); set => relativePosition = value;}
		private float cardRotation{get => -(GameMouse.Position.Y/Game1.Height-1)*(GameMouse.Position.Y/Game1.Height+1.2f);}
        public int CardNumber;

        public CreationManager(int number){
            CardNumber = number;
        }
		public void OnCreation(){
			if(GameMouse.IsClicking && GameMouse.IsInside){
				for(int i = 0; i < 3; i++){
					if (CardNumber == i && !Level1.Cards[i].Hitbox.Contains(GameMouse.Position)){
						Level1.CreateObject(new Creature(Level1.Cards[i].Content, CardPosition + MatrixPosition- new Vector2(0, 32+64)), ref Level1.Creature1);
						Level1.Player1.Mana -= Level1.Cards[i].Content.Cost;
					}
				}
				CardNumber = -1;
				Level1.CreationManager = null;
			}
		}
		public void Draw(GraphicsDevice graphicsDevice){
			Vector2[] Vertices = {new Vector2(30*cardRotation, 200*cardRotation), new Vector2(0, SpriteCard.Height), new Vector2(SpriteCard.Width, SpriteCard.Height), new Vector2(SpriteCard.Width-30*cardRotation, 200*cardRotation)};
			Vector2[] OtherVert = {new Vector2(0,0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)};

			VertexPositionColorTexture[] vertexPositionColors = new VertexPositionColorTexture[8];
			BasicEffect basicEffect;
			for(int i = 0; i < 8; i++){
				vertexPositionColors[i] = new VertexPositionColorTexture(new Vector3(Vertices[(i%4)]+CardPosition-new Vector2(64+60, 96+60+150), 0), new Color(79,79,79),OtherVert[i%4]);
			}
			basicEffect = new BasicEffect(graphicsDevice);
			basicEffect.Texture = SpriteCard;
			basicEffect.TextureEnabled = true;
			basicEffect.VertexColorEnabled = true;
			basicEffect.World = Matrix.CreateOrthographicOffCenter(0, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height, 0, 0, 1);
			basicEffect.CurrentTechnique.Passes[0].Apply();
		    graphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, vertexPositionColors, 0, 5);
		}
		public void Draw(SpriteBatch batch){
            Vector2 position = CardPosition+MatrixPosition-new Vector2(0, 96-100*(cardRotation)+100);
            float depth = (-position.Y / (Game1.MapLimit+1)) + 0.5f;
			batch.Draw(Level1.Cards[CardNumber].Content.Sprite, position, new Rectangle(256, 0, 128, 128), Color.White, 0, Vector2.One*64, 1, SpriteEffects.None, depth);
    	}
	}
}