using System.Collections.Generic;

namespace TextAdventure
{
    /// <summary>
    /// Class for locations.
    /// </summary>
    public class Location
    {
        private string Name { get; set; }

        private string Description { get; set; }

        private List<Exit> exits = new List<Exit>();

        private List<Enemy> enemies = new List<Enemy>();

        public Inventory inventory = new Inventory(10);

        /// <summary>
        /// Defualt contructor for Location class.
        /// </summary>
        public Location()
        {
        }

        /// <summary>
        /// Creates a new location with the given title and description.
        /// </summary>
        /// <param name="title">Title of the location.</param>
        /// <param name="description">Description of the location.</param>
        public Location(string title = "", string description = "")
        {
            Name = title;
            Description = description;
        }

        /// <summary>
        /// returns room title.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        public void AddExit(Exit exit)
        {
            exits.Add(exit);
        }

        public void RemoveExit(Exit exit)
        {
            if (exits.Contains(exit))
            {
                exits.Remove(exit);
            }
        }

        public List<Exit> GetExits()
        {
            return new List<Exit>(exits);
        }

        public List<Item> GetInventory()
        {
            return inventory.GetItems();
        }

        public void AddItem(Item itemToAdd)
        {
            inventory.AddItem(itemToAdd);
        }

        public void RemoveItem(Item itemToRemove)
        {
            if (inventory.GetItems().Contains(itemToRemove))
            {
                inventory.RemoveItem(itemToRemove);
            }
        }

        public Item TakeItem(string name)
        {
            foreach (Item _item in inventory.GetItems())
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

        public string GetTitle()
        {
            return Name;
        }

        public void SetTitle(string title)
        {
            Name = title;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void AddEnemy(Enemy enemyToAdd)
        {
            enemies.Add(enemyToAdd);
        }

        public List<Enemy> GetEnemies()
        {
            return new List<Enemy>(enemies);
        }

        public void RemoveEnemy(Enemy enemyToRemove)
        {
            if (enemies.Contains(enemyToRemove))
            {
                enemies.Remove(enemyToRemove);
            }
        }
    }
}