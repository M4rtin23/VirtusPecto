namespace VirtusPecto.Desktop{
	public abstract class UIElement{
		public bool State;
		protected string name;
		public abstract void Update(float x, float y);
		public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
	}
}