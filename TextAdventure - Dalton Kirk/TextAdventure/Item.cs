using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Item
	{
        
        private List<Item> playerInventory;
        public string name = "";
        public bool canAdd = true;
        public bool isAccessible = false;
        public bool isEmpty = false;
        public bool isContainer = false;
        public int damage = 1;

        public Item()
		{
            
            playerInventory = new List<Item>();
            
		}

        public void AddItem(Item item)
        {
            playerInventory.Add(item);

        }
        public void RemoveItem(Item item)
        {

        }

        public List<Item> getInventory()
        {
            return new List<Item>(playerInventory);
        }
         
        
      


    }
}
