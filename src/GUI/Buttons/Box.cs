namespace VirtusPecto.Desktop{
	public abstract class Box{
		public bool State;
		public abstract void Update(float x, float y);
		public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
	}
}