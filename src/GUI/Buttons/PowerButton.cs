using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;


namespace VirtusPecto.Desktop{
	public class PowerButton{
		protected Rectangle hitbox {get => new Rectangle(Position.ToPoint(), new Point(128));}
		public Vector2 Position;
		static float timer;
		public float Timer{get => timer; set => timer = value;}
		bool checker, state;
		public PowerButton(){
		}
		public void Update(){
			Position = new Vector2(0, Game1.Height-128);
			if(timer <= 0){
				if(hitbox.Contains(Game1.Mouse1.Position)){
					if(Game1.IsClicking){
						checker = true;
					}else if(checker){
						Game1.Level1.Player1.UsePower(Level1.Player1.GetPowerIndex());
						checker = false;
						state = !state;
						timer = 60;
					}
				}else{
					checker = false;
				}
			}
			if(timer > 0){
				timer--;
			}
		}

		public void Draw(SpriteBatch batch){
			int a = (int)((60-timer)/60*155+100);
			int a1 = (60-(int)timer)/60*128+128;
			batch.Draw(Game1.SpritePowers, Position, new Rectangle(0, 0, 128,128), new Color(16,16,16,a/2));
			batch.Draw(Game1.SpritePowers, Position, new Rectangle(128*(Level1.Player1.GetPowerIndex()+1)*0+128*3, 0, 128,128), new Color(a1,a1,a1,a1));
		}
	
		public static bool IsCharged(){
			return timer <= 0;
		}
		public static bool CanShoot(){
			bool i = timer <= 0;
			if(i){
				timer = 60;
			}
			return i;
		}
	}
}