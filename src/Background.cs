using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Game1;

namespace VirtusPecto.Desktop{
	public class BackGround{
		private Texture2D backGround;
		private Vector2 position;
		public BackGround(Texture2D texture){
			backGround = texture;
			position = new Vector2(0, 0);
		}
		public void Draw(SpriteBatch batch, Vector2 center){
			Vector2 windowSize = new Vector2(Width,Height);
			int width = backGround.Width/4, height = backGround.Height;
			int x1 = (int)Math.Ceiling((decimal)Width/width);
			int y1 = (int)Math.Ceiling((decimal)Height/height);
			for(int x = -1; x < x1+1; x++){
				position.X = (width*((int)(center.X/width))) + width * x;
				for(int y = -1; y < y1+1; y++){
					position.Y = (height*((int)(center.Y/height))) + height * y;
					int i;
					if((position.X * position.Y) % 7 == 1){
						i = (int)((Math.Sin(position.X + position.Y) + 1) * GT.TotalGameTime.Milliseconds) % 1200;
						i = i/400+1;
					}else{
						i = 0;
					}
					batch.Draw(backGround, position - windowSize/2, new Rectangle(i*128, 0, 128, 128), Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 1);
				}
			}
		}
	}
}