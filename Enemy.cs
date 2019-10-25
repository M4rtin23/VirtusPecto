using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Level;
using static VirtusPecto.Desktop.Game1;
using static GameBuilder.Builder;

namespace VirtusPecto.Desktop{
    public class Enemy : GameBuilder.ObjectBuilder{
        bool m = false;
        public Enemy(int x,int y){
            if(x <= 0){
                m = true;
            }
			SpriteIndex = Sprite0;
			Position = new Vector2(x, y);
		}
		public override void Update() {
            Hitbox = new Rectangle((int) Position.X - 32 + 16, (int) Position.Y - 64 + 16, 96 - 16, 128 - 16);
            if(m){
                speed = Follow(Levels.Player1.Position, Position, Levels.Player1.Hitbox.Height, 3);
            }
            base.Update();
		}
		public override void Draw(SpriteBatch sprBt) {
            center(4);
            stripToSprite(4);
            base.Draw(sprBt);
        }
    }
}
