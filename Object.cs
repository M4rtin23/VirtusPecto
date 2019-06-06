using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static VirtusPecto.Desktop.Game1;
using static VirtusPecto.Desktop.Level;
using static GameMaker.MakerObject;

namespace VirtusPecto.Desktop{
    public class Object{
        public Vector2 Position;
        private Texture2D SpriteIndex;
		private float imageIndex;
		private float animationSpeed;
		private SpriteEffects effect;
		private Vector2 speed;
        public Rectangle Hitbox;
        public Object(int x, int y){
            Position = new Vector2(x, y);
        }
        protected virtual void Update(){

        }
        protected virtual void Draw(){

        }
    }
}