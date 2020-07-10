namespace TextAdventure
{
    public class Enemy
    {
        public Enemy(string name, int startHealth, int startDamage)
        {
            health = startHealth;
            this.name = name;
            damage = startDamage;
        }

        public int health;
        public int damage;
        public string name;
    }
}