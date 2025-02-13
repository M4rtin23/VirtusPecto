using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class OptionBox{
		protected string name;
		protected Rectangle hitbox{get => new Rectangle((int)position.X,(int)position.Y,128,32);}
		protected Vector2 position;
		private Color color;
		public Vector2[] Options;
		private Color[] colors;
		private bool isActivated;
		protected int optionsNumber {get => Options.Length; set {Options = new Vector2[value]; colors = new Color[optionsNumber];}}
		public int Option;

		protected virtual void action(int i){}

		protected virtual string drawOptions(int i){
			return null;
		}
		protected virtual string currentOption(){
			return drawOptions(Option);
		}
		public void Update(float x, float y){
			position = new Vector2(x, y);
			if (hitbox.Contains(GameMouse.Position)){
				Mouse1.Click(() => {isActivated = !isActivated;});
			}
			if (isActivated){
				for (int i = 0; i < optionsNumber; i++){
					Rectangle r = new Rectangle((int)position.X, (int)position.Y + (1 + i)*32, 128, 32);
					if (r.Contains(GameMouse.Position)){
						if (GameMouse.IsClicking){
							Option = i;
							action(i);
							isActivated = false;
						}
						colors[i] = Color.LightBlue;
					}else{
						colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public void Draw(SpriteBatch batch) {
			new GameBuilder.Shapes.RectangleF(position, new Vector2(128,32), color).Draw(batch);
			batch.DrawString(FontNormal, currentOption(), position, Color.White);
			batch.DrawString(FontNormal, name, new Vector2(position.X, position.Y - 32), Color.White);

			if (isActivated) {
				color = Color.LightGray;
				for (int i = 0; i < optionsNumber; i++){
					new GameBuilder.Shapes.RectangleF(new Vector2(position.X, position.Y+(1+i)*32), new Vector2(128,32), colors[i]).Draw(batch);
					batch.DrawString(FontNormal, drawOptions(i), new Vector2(position.X, position.Y + (i+1) * 32), Color.White);
				}
			}else{
				color = Color.DarkGray;
			}
		}
	}
}
