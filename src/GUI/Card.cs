using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder;
using static GameBuilder.GameBase;

namespace VirtusPecto.Desktop{
	public class Card{
		public Texture2D SpriteIndex;
		public RectangleF Hitbox{get => new RectangleF((Position.X-SpriteIndex.Width/2), (Height + addedY  - 64*(1-Math.Abs(number-1)) - 96-SpriteIndex.Height/2), SpriteIndex.Width, SpriteIndex.Height);}
		public Vector2 Position{get => new Vector2(Width / 2 + SpriteIndex.Width * (number-1), Height + addedY  - 64*(1-Math.Abs(number-1)) - 96);}
		public CardContent Content;
		private int addedY, number;
		private Color cardColor, color;
		int addvalue;

		public Card(int n, Color c){
			cardColor = Color.DarkSlateGray;
			cardColor = c;
			cardColor = new Color(79,79,79);
			number = n;
			Content = Level1.Player1.Slot[n];
			addedY = 128;
			SpriteIndex = Game1.SpriteCard;
		}
		public void Update() {
			if (Level1.Player1.Mana >= Content.Cost){
				if (Hitbox.Contains(Mouse1.Position)){
					if(addedY > 64*(1-Math.Abs(number-1))){
						addedY -= 16;
					}
					if (IsClicking){
						addedY = 128;
						Mouse1.Number = number;
						Mouse1.IsCreating = true;
						Mouse1.CardPosition = Mouse1.Position-Position;
					}
				}else{
					if(addedY < 128){
						addedY += 16;
					}
				}
			}else{
				addedY = 128;
			}
			if(Mouse1.IsInside){
				addvalue -= 8;
			}else{
				addvalue += 8;
			}
			if(addvalue > 0){
				addvalue -= 8;
			}
			if(addvalue < -64){
				addvalue += 8;
			}
		}
		public void Draw(SpriteBatch batch){
			Vector2 Position2 = Position - new Vector2(0, addvalue);
			if(!(Mouse1.Number == number && Mouse1.IsCreating)){
			if (!Mouse1.IsCreating){
				color = new Color(cardColor, 255);
			}
			else {
		//		color = new Color(cardColor.R/2, cardColor.G/2, cardColor.B/2, 128);
			}
			float rot = ((float)addedY)/256f * (number-1);
			/*if(Mouse1.IsCreating){
				Position.Y += 64;
			}*/
			batch.Draw(SpriteIndex, Position2, null, color, rot, SpriteIndex.Bounds.Size.ToVector2()/2, 1,SpriteEffects.None, 1);
			batch.Draw(Content.Sprite, new Vector2(Position2.X, Position2.Y), new Rectangle(2 * 128, 0, 128, 128), new Color(255,255,255, (int)color.A), rot, new Vector2(64,160), 1, SpriteEffects.None, 0);

			if (Hitbox.Contains(Mouse1.Position)){
				batch.DrawString(FontNormal, Content.Name, Position2, Color.White, rot, new Vector2(112, 204), 1, SpriteEffects.None, 0); 
				if(IsDescriptionOn){
					string description = "*Atk: " + Content.Atk+"*HP: "+Content.HP+"*Speed: "+ Content.Spd;
					description = description.Replace("*", System.Environment.NewLine);
					batch.DrawString(FontNormal, description, Position2, Color.White, rot, new Vector2(100, 48), 1, SpriteEffects.None, 0); 
				}
			}
			batch.DrawString(FontNormal, ""+Content.Cost, Position2, Color.White, rot, new Vector2(-92, 188), 1, SpriteEffects.None, 0); 
		}}
	}
}
