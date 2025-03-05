using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;
using GameBuilder.Shapes;

namespace VirtusPecto.Desktop{
	public class Slide : Box{
		Vector2 position;
		RectangleF point = new RectangleF(Vector2.Zero, 16);
		Line line = new Line(Vector2.Zero, Vector2.One);
		float rel, relativePosition, length = 128;
		bool check;
		
		public Slide(string name, float value){
			this.name = name;
			relativePosition = value*1.28f;
		}

        public override void Update(float x, float y){
			position = new Vector2(x, y + 16);
			point.Location = position - Vector2.UnitY*point.Size/2 + Vector2.UnitX*relativePosition;
			line = new Line(position, position + Vector2.UnitX*length, 8, Color.White);
			Mouse1.Click(point, () => {rel = GameMouse.Position.X-relativePosition-line.Min.X; check = true;});

			if(GameMouse.IsClicking && check){
				relativePosition = GameMouse.Position.X-rel-position.X;
			}
			if(!GameMouse.IsClicking){
				check = false;
			}
			if(point.X < line.Min.X){
				point.X = line.Min.X;
				relativePosition = 0;
			}
			if(point.X > line.Max.X){
				point.X = line.Max.X;
				relativePosition = length;
			}
        }
        public override void Draw(SpriteBatch spriteBatch){
			point.Draw(spriteBatch);
			line.Draw(spriteBatch);
			spriteBatch.DrawString(FontNormal, name+": "+(int)((point.X-line.Min.X)/(line.Max.X - line.Min.X)*100), position - new Vector2(0, 48), Color.White);
        }
    }
}