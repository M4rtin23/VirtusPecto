using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;
using static GameBuilder.GameType.FixedView;

namespace VirtusPecto.Desktop{
	public class Card{
		public Texture2D SpriteIndex = SpriteCard;
		public RectangleF Hitbox{get => new RectangleF((Position.X-SpriteIndex.Width/2), (Height + addedY  - 64*(1-Math.Abs(number-1)) - 96-SpriteIndex.Height/2), SpriteIndex.Width, SpriteIndex.Height);}
		public Vector2 Position{get => new Vector2(Width / 2 + SpriteIndex.Width * (number-1), Height + addedY  - 64*(1-Math.Abs(number-1)) - 96);}
		public CardContent Content;
		private int addedY, number;
		private Color cardColor = new Color(79,79,79);
		int addvalue = 128;

		public Card(int n, Color c){
			number = n;
			Content = Level1.Player1.Slot[n];
		}
		public void Update() {
			if (Level1.Player1.Mana >= Content.Cost){
				if (Hitbox.Contains(GameMouse.Position)){
					if(addedY > 64*(1-Math.Abs(number-1))){
						addedY -= 16;
					}
					if (GameMouse.IsClicking){
						Level1.CreationManager = new CreationManager(number);
						Level1.CreationManager.CardPosition = GameMouse.Position-Position;
					}
				}else{
					if(addedY < 128){
						addedY += 16;
					}
				}
			}else{
				addedY = 128;
			}
			if(GameMouse.IsInside && addvalue > -64){
				addvalue -= 8;
			}
			if(!GameMouse.IsInside && addvalue < 0){
				addvalue += 8;
			}
		}
		public void Draw(SpriteBatch batch){
			Vector2 Position2 = Position - new Vector2(0, addvalue);
			if(Level1.CreationManager?.CardNumber != number){
				float rot = addedY / 256f * (number-1);
				batch.Draw(SpriteIndex, Position2, null, cardColor, rot, SpriteIndex.Bounds.Size.ToVector2()/2, 1,SpriteEffects.None, 1);
				batch.Draw(Content.Sprite, Position2, new Rectangle(2 * 128, 0, 128, 128), new Color(255,255,255, (int)cardColor.A), rot, new Vector2(64,160), 1, SpriteEffects.None, 0);

				if (Hitbox.Contains(GameMouse.Position)){
					batch.DrawString(FontNormal, Content.Name, Position2, Color.White, rot, new Vector2(112, 204), 1, SpriteEffects.None, 0);
					if(IsDescriptionOn){
						string description = "\nAtk: " + Content.Atk+"\nHP: "+Content.HP+"\nSpeed: "+ Content.Spd;
						batch.DrawString(FontNormal, description, Position2, Color.White, rot, new Vector2(100, 48), 1, SpriteEffects.None, 0);
					}
				}
				batch.DrawString(FontNormal, ""+Content.Cost, Position2, Color.White, rot, new Vector2(-92, 188), 1, SpriteEffects.None, 0);
			}
		}
	}
}
