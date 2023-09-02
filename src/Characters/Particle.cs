using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameBuilder.Shapes;


namespace VirtusPecto.Desktop{
    public class Particle{
        private Vector2 position;
        private Texture2D spriteIndex;
        private float angle;
        private int timer, maxTimer;
        int type;
        int x;
        public Particle(Texture2D texture, Vector2 position, float angle, float seconds){
            this.position = position;
            this.spriteIndex = texture;
            this.timer = (int)(seconds*60);
            this.maxTimer = timer;
            this.angle = angle;
        }
        public Particle(Vector2 position, float angle, float seconds, int type){
            this.position = position;
            this.timer = (int)(seconds*60);
            this.maxTimer = timer;
            this.angle = angle;
            this.type = type;
            x = new System.Random(Game1.GT.TotalGameTime.Milliseconds).Next(-128,128);
        }
        public void Update(){
            timer--;
            if(timer < 0){
                Game1.Level1.DestroyParticle();
            }
        }
        public bool GetState(){
            return timer > 0;
        }
        public void Draw(SpriteBatch batch){
            if(type == 0){
                new Line(position, position + new Vector2(x, -Game1.Height), 6, new Color(0,0,255-(maxTimer-timer)*255/maxTimer,255-(maxTimer-timer)*255/maxTimer)).Draw(batch);
            }else{
                new RectangleF(position, Vector2.One*64, new Color(255-(maxTimer-timer)*255/maxTimer, 255-(maxTimer-timer)*255/maxTimer, 255-(maxTimer-timer)*255/maxTimer, 255-(maxTimer-timer)*255/maxTimer)).Draw(batch);
            }
        }
    }
}