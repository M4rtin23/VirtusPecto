using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.CreatureDatabase;

namespace VirtusPecto.Desktop{
	public class Card{
		public Texture2D SpriteIndex;
		public Rectangle GetCollision;
		public Vector2 Origin, Position;
		public CardContent Content;
		private int number;
		private int addedY;
		private Color cardColor, color;

        public Card(int n, Color c){
			cardColor = c;
			number = n;
			Content = Levels.Player1.Slot[n];
			addedY = 128;
			SpriteIndex = Game1.Sprite1;
			Origin = new Vector2(SpriteIndex.Width / 2, SpriteIndex.Height / 2);
			Position = new Vector2(0,0);
			GetCollision = new Rectangle((int)Position.X, (int)Position.Y, SpriteIndex.Width, SpriteIndex.Height);
		}
		public void Update() {
			GetCollision = new Rectangle((int)(Position.X-Origin.X), (int)(Position.Y-Origin.Y), SpriteIndex.Width, SpriteIndex.Height);
			Position.Y = graphics.PreferredBackBufferHeight + addedY  - 64*(1-Math.Abs(number-1)) - 32;
			Position.X = graphics.PreferredBackBufferWidth / 2 + SpriteIndex.Width * (number-1);
            //Position.X = graphics.PreferredBackBufferWidth * (number+1) / 4;
			if (!mouse.IsCreating && Levels.Creature1 == null){
				if (GetCollision.Intersects(mouse.GetCollision)){
					addedY = 0;
					if (/*Mouse.GetState().LeftButton == ButtonState.Pressed*/IsClicking){
						addedY = 128;
						mouse.number = number;
						mouse.IsCreating = true;
					}
				}else{
					addedY = 128;
				}
			}else{
				addedY = 128;
			}
		}
		public void Draw(){
			if (!mouse.IsCreating && Levels.Creature1 == null){
				color = cardColor;
			}
			else {
				color = Color.DarkGray;
			}
            float rot = ((float)addedY)/256f * (number-1);
            spriteBatch.Draw(SpriteIndex, Position, null, color, rot, SpriteIndex.Bounds.Size.ToVector2()/2, 1,SpriteEffects.None, 1);
			spriteBatch.Draw(Content.Sprite, new Vector2(Position.X, Position.Y), new Rectangle(2 * 128, 0, 128, 128), Color.White, rot, new Vector2(64,160), 1, SpriteEffects.None, 0);
            if (GetCollision.Intersects(mouse.GetCollision) && !mouse.IsCreating){
                if(IsDescriptionOn){
				    spriteBatch.DrawString(Font, Content.Description, mouse.Position-new Vector2(0, 96), Color.White);
                }else{
                    spriteBatch.DrawString(Font, Content.Name, mouse.Position-new Vector2(-8, 0), Color.White);
                }
			}
        }
    }
}
