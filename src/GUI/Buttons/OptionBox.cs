using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class OptionBox : Box{
		protected string name, option, separator;
		protected Rectangle hitbox{get => new Rectangle((int)position.X,(int)position.Y,128,32);}
		protected Vector2 position;
		private Color color;
		public Vector2[] Options;
		private Color[] colors;
		protected int optionsNumber {get => Options.Length; set {Options = new Vector2[value]; colors = new Color[optionsNumber];}}
		public int Option;
		Action action;


		public OptionBox(string name, int optionNumber, string separator, Vector2[] options, Action action){
			this.name = name;
			this.optionsNumber = optionNumber;
			this.separator = separator;
			Options = options;
			this.action = action;
			option = " "+ (int)Options[Option].X + separator + (int)Options[Option].Y;
			option = option.Split("\0")[0];
		}
		public void SetDefaultOption(string str){
			option = str;
		}
		public override void Update(float x, float y){
			position = new Vector2(x, y);
			if (hitbox.Contains(GameMouse.Position)){
				Mouse1.Click(() => {State = !State;});
			}
			if(State){
				for (int i = 0; i < optionsNumber; i++){
					Rectangle r = new Rectangle((int)position.X, (int)position.Y + (1 + i)*32, 128, 32);
					if (r.Contains(GameMouse.Position)){
						if (GameMouse.IsClicking){
							Option = i;
							action();
							State = false;
							option = (" "+ (int)Options[Option].X + separator + (int)Options[Option].Y).Split("\0")[0];
						}
						colors[i] = Color.LightBlue;
					}else{
						colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public override void Draw(SpriteBatch batch) {
			new GameBuilder.Shapes.RectangleF(position, new Vector2(128,32), color).Draw(batch);
			batch.DrawString(FontNormal, option, position, Color.White);
			batch.DrawString(FontNormal, name, new Vector2(position.X, position.Y - 32), Color.White);

			if(State) {
				color = Color.LightGray;
				for (int i = 0; i < optionsNumber; i++){
					new GameBuilder.Shapes.RectangleF(new Vector2(position.X, position.Y+(1+i)*32), new Vector2(128,32), colors[i]).Draw(batch);
					batch.DrawString(FontNormal, (" "+ (int)Options[i].X + separator + (int)Options[i].Y).Split("\0")[0], new Vector2(position.X, position.Y + (i+1) * 32), Color.White);
				}
			}else{
				color = Color.DarkGray;
			}
		}
	}
}
