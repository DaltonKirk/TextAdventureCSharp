using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Location
    {
        private string roomTitle;
        private string roomDescription;
        private List<Exit> exits;
		private List<Enemy> enemies;
        public  Inventory inventory = new Inventory(10);

        public Location()
        {
            // Blank out the title and description at start
			roomTitle = "";
			roomDescription = "";
			exits = new List<Exit>();
			enemies = new List<Enemy>();
        }

		public Location(string title)
		{
			roomTitle = title;
			roomDescription = "";
			exits = new List<Exit>();
            enemies = new List<Enemy>();

        }

        public Location(string title, string description)
		{
			roomTitle = title;
			roomDescription = description;
			exits = new List<Exit>();
            enemies = new List<Enemy>();
		}


		public override string ToString()
		{
			return roomTitle;
		}

		public void addExit(Exit exit)
		{
			exits.Add(exit);
		}

		public void removeExit(Exit exit)
		{
			if (exits.Contains(exit))
			{
				exits.Remove(exit);
			}
		}

		public List<Exit> getExits()
		{
			return new List<Exit>(exits);
		}

		public List<Item> getInventory()
		{
		    return inventory.GetItems();
		}

		public void addItem(Item itemToAdd)
		{
			inventory.AddItem(itemToAdd);
		}

		public void removeItem(Item itemToRemove)
		{
			if ( inventory.GetItems().Contains(itemToRemove) )
			{
				inventory.RemoveItem(itemToRemove);
			}
		}

		public Item takeItem(string name)
		{
			foreach ( Item _item in inventory.GetItems() )
			{
                if (_item.name == name)
				{
					Item temp = _item;
					inventory.RemoveItem(temp);
					return temp;
				}
			}

			return null;
		}

		public string getTitle()
		{
			return roomTitle;
		}

		public void setTitle(string title)
		{
			roomTitle = title;
		}

		public string getDescription()
		{
			return roomDescription;
		}

		public void setDescription(string description)
		{
			roomDescription = description;
		}

        public void addEnemy(Enemy enemyToAdd)
        {
            enemies.Add(enemyToAdd);
        }

        public List<Enemy> getEnemies()
        {
            return new List<Enemy>(enemies);
        }
        public void removeEnemy(Enemy enemyToRemove)
        {
            if (enemies.Contains(enemyToRemove))
            {
                enemies.Remove(enemyToRemove);
            }
        }
    }
}
