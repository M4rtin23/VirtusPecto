using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;

namespace VirtusPecto.Desktop{
	public class OptionBox{
		protected string name;
		protected Rectangle hitbox;
		public Vector2 Position;
		private Color color;
		public Vector2[] Options;
		public Color[] Colors;
		public bool isActivated;
		public int OptionsNumber;
		bool checker;
		//protected int Number;

		public OptionBox(){
			OptionsNumber = n();
			Options = new Vector2[OptionsNumber];
			Colors = new Color[OptionsNumber];
			hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);
			for (int i = 0; i < OptionsNumber; i++){                
				Colors[i] = Color.DarkGray;
			}
		}
		protected virtual void action(int i){}
		//Don't be lazy and change it.
		//Don't be lazy and change it.
		//Don't be lazy and change it.
		//Don't be lazy and change it.
		//Don't be lazy and change it.

		protected virtual void update(){}
		protected virtual int n(){return 0;}
		public void SetPosition(float x, float y){
			Position = new Vector2(x, y);
		}
		protected virtual string drawOptions(int i){
			return null;
		}
		protected virtual string currentOption(){
			return null;
		}
		public void Collision() {
			hitbox = new Rectangle((int)Position.X, (int)Position.Y, 128, 32);
		//Don't be lazy and change it.
		//Don't be lazy and change it.
		//Don't be lazy and change it.
			update();
			if (hitbox.Contains(Mouse1.Position)){
				if(IsClicking()){
					checker = true;
				}else if(checker){
					isActivated = !isActivated;
					checker = false;
				}
			}else{
				checker = false;
			}
			if (isActivated){
				for (int i = 0; i < OptionsNumber; i++){
					Rectangle r = new Rectangle((int)Position.X, (int)Position.Y + (1 + i)*32, 128, 32);
					if (r.Contains(Mouse1.Position)){
						if (IsClicking()){
							action(i);
							isActivated = false;
						}
						Colors[i] = Color.LightBlue;
					}else{
						Colors[i] = Color.DarkGray;
					}
				}
			}
		}
		public void Draw(SpriteBatch batch) {
			batch.Draw(Sprite2, Position, color);
			batch.DrawString(Font, currentOption(), Position, Color.White);
			batch.DrawString(Font, name, new Vector2(Position.X, Position.Y - 32), Color.White);

			if (isActivated) {
				color = Color.LightGray;
				for (int i = 0; i < OptionsNumber; i++){
					batch.Draw(Sprite2, new Vector2(Position.X, Position.Y+(1+i)*32), Colors[i]);
					batch.DrawString(Font, drawOptions(i), new Vector2(Position.X, Position.Y + (i+1) * 32), Color.White);
				}
			}else{
				color = Color.DarkGray;
			}
		}
	}
}
