using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Item
	{
        public string name = "";
        public bool canAdd = true;
        public bool isAccessible = false;
        public bool isEmpty = false;
        public bool isContainer = false;
        public int damage = 1;

    }
}
