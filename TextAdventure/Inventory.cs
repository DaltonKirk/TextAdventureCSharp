using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Inventory
    {
        private List<Item> items = new List<Item>();
        private int capacity;

        public Inventory(int setCapacity)
        {
            capacity = setCapacity;
        }

        public void AddItem(Item item)
        {
            if (items.Count < capacity)
            {
                items.Add(item);
            }
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void PrintItems()
        {
            Console.WriteLine("A quick look in your bag reveals the following:\n");

            if (items.Count == 0)
            {
                Console.WriteLine("Your bag is empty.");
                return;
            }

            foreach (var item in items)
            {
                Console.WriteLine(item.name);
            }
        }

        public List<Item> GetItems()
        {
            return items;
        }
    }
}
