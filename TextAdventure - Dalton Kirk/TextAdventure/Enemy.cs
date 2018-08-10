using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Enemy
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
