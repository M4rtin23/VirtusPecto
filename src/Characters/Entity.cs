namespace VirtusPecto.Desktop{
    public class Entity : GameBuilder.InGame.ObjectBuilder, INullable{
        protected float health;
        protected int powerIndex;
        public void AddHealth(int number){
			health += number;
		}
		public float GetHealth(){
			return health;
		}
		public bool GetState(){
			return health > 0;
		}
    }
}