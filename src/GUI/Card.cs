using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.CreatureDatabase;
using static GameBuilder.Game1;

namespace VirtusPecto.Desktop{
	public class Card{
		public Texture2D SpriteIndex;
		public Rectangle Hitbox;
		public Vector2 Position;
		public CardContent Content;
		private int number;
		private int addedY;
		private Color cardColor, color;

		public Card(int n, Color c){
			cardColor = c;
			number = n;
			Content = Level1.Player1.Slot[n];
			addedY = 128;
			SpriteIndex = Game1.Sprite1;
			Position = new Vector2(0,0);
			Hitbox = new Rectangle((int)Position.X, (int)Position.Y, SpriteIndex.Width, SpriteIndex.Height);
		}
		public void Update() {
			Hitbox = new Rectangle((int)(Position.X-SpriteIndex.Width/2), (int)(Position.Y-SpriteIndex.Height/2), SpriteIndex.Width, SpriteIndex.Height);
			Position.Y = Height + addedY  - 64*(1-Math.Abs(number-1)) - 32;
			Position.X = Width / 2 + SpriteIndex.Width * (number-1);
			//Position.X = Width * (number+1) / 4;
			if (!Mouse1.IsCreating && /*Level1.Creature1 == null */Level1.Player1.Mana >= 50){
				if (Hitbox.Contains(Mouse1.Position)){
					if(addedY > 0){
						addedY -= 16;
					}
					if (IsClicking()){
						addedY = 128;
						Mouse1.Number = number;
						Mouse1.IsCreating = true;
					}
				}else{
					if(addedY < 128){
						addedY += 16;
					}
				}
			}else{
				addedY = 128;
			}
		}
		public void Draw(SpriteBatch batch){
			//if (!Mouse1.IsCreating && Level1.Creature1 == null){
				color = cardColor;
			/*}
			else {
				color = Color.DarkGray;
			}*/
			float rot = ((float)addedY)/256f * (number-1);
			batch.Draw(SpriteIndex, Position, null, color, rot, SpriteIndex.Bounds.Size.ToVector2()/2, 1,SpriteEffects.None, 1);
			batch.Draw(Content.Sprite, new Vector2(Position.X, Position.Y), new Rectangle(2 * 128, 0, 128, 128), Color.White, rot, new Vector2(64,160), 1, SpriteEffects.None, 0);
			if (Hitbox.Contains(Mouse1.Position) && !Mouse1.IsCreating){
				if(IsDescriptionOn){
					string description = Content.Name + "*Atk: " + Content.Atk+"*HP: "+Content.HP+"*Speed: "+ Content.Spd;
					description = description.Replace("*", System.Environment.NewLine);
					batch.DrawString(Font, description, Mouse1.Position-new Vector2(0, 96), Color.White);
				}else{
					batch.DrawString(Font, Content.Name, Mouse1.Position-new Vector2(-8, 0), Color.White);
				}
			}
			batch.DrawString(Font, "50", Position,Color.White,rot, new Vector2(-92, 188), 1,SpriteEffects.None, 0); 
		}
	}
}
