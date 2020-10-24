using GameBuilder;

namespace VirtusPecto.Desktop{
    public class Characters : ObjectBuilder{
        protected float health;
        protected int powerIndex;
        public void AddHealth(int number){
			health += number;
		}
		public float GetHealth(){
			return health;
		}
    }
}