using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static VirtusPecto.Desktop.Game1;


namespace VirtusPecto.Desktop{
    public class PowerButton{
        protected Rectangle hitbox;
        public Vector2 Position;
        static float timer;
        bool checker, state;
        public PowerButton(){
        }
        public void Update(){
            Position = new Vector2(64, Game1.Height()-192);
            hitbox = new Rectangle(Position.ToPoint(), new Point(128));
            if(timer <= 0){
                if(hitbox.Contains(Game1.Mouse1.Position)){
                    if(Game1.IsClicking){
                        checker = true;
                    }
                    if(checker && !Game1.IsClicking){
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

        public void Draw(SpriteBatch sprBt){
            int a = (int)((60-timer)/60*155+100);
            int a1 = (60-(int)timer)/60*128+128;
//            sprBt.Draw(Game1.Power, Position, new Rectangle(0, 0, 128,128), new Color(255/alpha,255/alpha,255/alpha,255/alpha));
//            sprBt.Draw(Game1.Power, Position, new Rectangle(128, 0, 128,128), new Color(255/alpha,255/alpha,255/alpha,255/alpha));
            sprBt.Draw(Game1.Power, Position, new Rectangle(0, 0, 128,128), new Color(16,16,16,a/2));
            sprBt.Draw(Game1.Power, Position, new Rectangle(128*(Level1.Player1.GetPowerIndex()+1), 0, 128,128), new Color(a1,a1,a1,a1));
        }
        public float GetTimer(){
            return timer;
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