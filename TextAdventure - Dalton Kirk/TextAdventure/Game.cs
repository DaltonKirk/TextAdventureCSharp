using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
	class Game
	{
		Location currentLocation;

        Item playerInventory;

		public bool isRunning = true;

        private string firstItem;
        
        private string secondItem;
        
        public string chosenWeapon;

        public int playerHealth;

        public bool dead;

        private List<Item> inventory;
        //making new locations, setting the title and description.
        Location l5 = new Location("Old Storage Room", "A few old boxes lay in the room covered with dust");
        Location l4 = new Location("Main hallway", "The walls are bare and theres nothing in here. Theres a door to the north,\nit looks rotten and easily breakable.");
        Location l9 = new Location("Inside The Log Cabin", "Theres an old chair next to the fireplace with lots of books scattered on the floor.");
        Location l8 = new Location("The Log Cabin", "The log cabin has a small sturdy looking door on the front,\n with a window to the right of it.");
        Location l10 = new Location("Bottom of the well", "It's very dark and you can hear the mud squelching under your feet.\n From out of the darkness a troll approaches you.");
        Location l11 = new Location("Trolls Lair", "The room is filled with treasure and you\nno longer care that you woke in a cave\n and you don't want to be an adventurer anymore" );
        //creating the new items
        Item chest = new Item();
        Item door = new Item();
        Item window = new Item();
        Item box = new Item();
        Item rope = new Item();
        Item well = new Item();
        Item currentWeapon = new Item();
        Item axe = new Item();
        Item stick = new Item();
        Item healthPotion = new Item();
        Enemy rat = new Enemy("Rat", 2, 1);



        public Game()
		{
			inventory = new List<Item>();
            playerInventory = new Item();
            playerHealth = 10;
            
			Console.WriteLine("Welcome to Adventure Game. Enter \"Help\" to see list of commands.");

			// build the "map"
			Location l1 = new Location("Cold Damp Cave", "You wake in a cold damp cave, it's very dark,\nbut you can see to the east is an exit.");
			l1.addItem(chest);
            chest.name = "chest";
            chest.canAdd = false;
            chest.isAccessible = false;
            chest.isContainer = true;


            Location l2 = new Location("Outside Cave Entrance", "You see vast amounts of vibrant fields lined with tall oak trees.\nYou can hear birds singing and smell the sweet scent of the meadow flowers.");

			Location l3 = new Location("Farm House", "You arrive at a house. The house has been freshly painted, you can tell by the smell. \nTo the east the front door seems to be left open");
            l3.addItem(axe);
            axe.name = "axe";
            axe.damage = 3;
            Location l6 = new Location("The Woods", "You stand in the woods to the north of the fields. \nTo the east is an old log cabin.\nTo the west is a well.");
            Location l7 = new Location("The Well", "You stand by the well, looking down there you see no water and can make out some sort of footprint in the damp mud.");
            //adding items and setting the values.
            Item rock = new Item();
            l8.addItem(rock);
            rock.name = "rock";
            l8.addItem(window);

            l1.addEnemy(rat);
            rat.name = "rat";
            rat.health = 2;
            rat.damage = 1;

            l1.addItem(stick);
            stick.name = "stick";
            stick.damage = 2;

            window.name = "window";
            window.canAdd = false;

            l9.addItem(rope);
            rope.name = "rope";


            l4.addItem (door);
            door.name = "door";
            door.canAdd = false;
            door.isContainer = true;

            l7.addItem(well);
            well.name = "well";
            well.canAdd = false;

            l1.addExit(new Exit(Exit.Directions.East, l2));
            l2.addExit(new Exit(Exit.Directions.West, l1));
            l2.addExit(new Exit(Exit.Directions.North, l6));
            l2.addExit(new Exit(Exit.Directions.East, l3));
            l3.addExit(new Exit(Exit.Directions.East, l4));
            l3.addExit(new Exit(Exit.Directions.West, l2));
            l4.addExit(new Exit(Exit.Directions.West, l3));
            l6.addExit(new Exit(Exit.Directions.West, l7));
            l6.addExit(new Exit(Exit.Directions.East, l8));
            l7.addExit(new Exit(Exit.Directions.East, l6));
            l8.addExit(new Exit(Exit.Directions.West, l6));
            l9.addExit(new Exit(Exit.Directions.West, l8));
            

            currentLocation = l1;
			showLocation();
		}

       
       
        public void showLocation()
		{
            Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(currentLocation.getDescription());

			if (currentLocation.getInventory().Count > 0)
			{
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine("\nThe room contains the following:\n");

				for ( int i = 0; i < currentLocation.getInventory().Count; i++ )
				{
					Console.WriteLine(currentLocation.getInventory()[i].name);
                    

                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (currentLocation.getEnemies().Count > 0)
            {
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nThis place contains the following enemies:\n");
                for (int i = 0; i < currentLocation.getEnemies().Count; i++)
                {
                    Console.WriteLine(currentLocation.getEnemies()[i].name);
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
	
			Console.WriteLine("\nAvailable Exits: \n");

			foreach (Exit exit in currentLocation.getExits() )
			{
				Console.WriteLine(exit.getDirection());
			}

			Console.WriteLine();
		}

        
		public void doAction(string command)
		{
			Console.WriteLine("\nInvalid command, are you confused?\n");
		}

		private void showInventory()
		{
			if ( playerInventory.getInventory().Count > 0 )
			{
				Console.WriteLine("\nA quick look in your bag reveals the following:\n");

                foreach (Item item in playerInventory.getInventory() )
				{
					Console.WriteLine(item.name);
				}
			}
			else
			{
				Console.WriteLine("Your bag is empty.");
			}

			Console.WriteLine("");
		}

        public void Update()


        {


            // if they character dies, disable the input, to prevent the game contiuning 
            while (dead)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                ConsoleKeyInfo key = Console.ReadKey(true);
            }

            //takes what the user types and sets it to current command and makes it lower case to help the input handling.
                string currentCommand = Console.ReadLine().ToLower();

            // instantly check for a quit
            #region QuitCommand
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }
            #endregion QuitCommand
            // if "i" is entered or "inventory" run the ShowInventory command
            #region inventoryCommand
            if (currentCommand == "inventory" || currentCommand == "i")
            {
                showInventory();
                return;
            }
            #endregion inventoryCommand

            #region TakeCommand
            // if player types add then it will take "add " from the string and check what is left.
            if (currentCommand.Contains("take"))
            {
                currentCommand = currentCommand.Remove(0, 5);
                // if what is left of the string is equal to an item in the current location remove it and add to player inventory
                for (int i = 0; i < currentLocation.getInventory().Count; i++)
                {
                    if (currentLocation.getInventory()[i].name == currentCommand && currentLocation.getInventory()[i].canAdd == true)
                    {


                        Item takenItem = currentLocation.takeItem(currentCommand);
                        playerInventory.AddItem(takenItem);
                        Console.Clear();
                        showLocation();
                        return;
                    }
                    else if (currentLocation.getInventory()[i].name == currentCommand && currentLocation.getInventory()[i].canAdd == false)
                    {
                        Console.WriteLine("You can't pick up that item!");
                        return;
                    }
                    //if remaining bit of string not equal to an item in location write this
                    else
                    {
                        Console.WriteLine("No such item");
                    }
                }

            }
            #endregion TakeCommand
            #region UseCommand
            if (currentCommand.Contains("use "))
            {
                currentCommand = currentCommand.Remove(0, 4);
                // if what is left of the string is equal to an item in the current player inventory
                if (playerInventory.getInventory().Count > 0)
                {
                    for (int i = 0; i < playerInventory.getInventory().Count; i++)
                    {
                        if (playerInventory.getInventory()[i].name == currentCommand)
                        {
                            Console.WriteLine("What do you want to use that with?");
                            secondItem = Console.ReadLine();
                            firstItem = currentCommand.ToString();
                            Console.WriteLine("You want to use " + currentCommand.ToString() + " with " + secondItem);
                            Use(firstItem, secondItem);
                            return;
                        }


                    }
                    // if no items in player inventory match currenCommand. display this message
                    Console.WriteLine("You have no such item.");
                    return;
                }
                // if theres no items in inv when trying to use somthing display this
                else
                {
                    Console.WriteLine("You have no items.");
                    return;
                }
            }


            else if (currentCommand == "use")
            {
                Console.WriteLine("Type \"use\" then a space, then the name of the item.");
                return;
            }
            #endregion UseCommand
            #region LookCommand
            if (currentCommand == "look")
            {
                Console.Clear();
                showLocation();
                return;
            }
            #endregion LookCammand
            #region OpenCommand
            //if they have entered the word open check locations inventory for the item they want
            if (currentCommand.Contains("open "))
            {
                currentCommand = currentCommand.Remove(0, 5);
                if (currentLocation.getInventory().Count > 0)
                {
                    for (int i = 0; i < currentLocation.getInventory().Count; i++)
                    {
                        if (currentLocation.getInventory()[i].name == currentCommand && currentLocation.getInventory()[i].isAccessible)
                        {
                            Open(currentCommand);
                            return;
                        }
                        else if (currentLocation.getInventory()[i].name == currentCommand && !currentLocation.getInventory()[i].isContainer)
                        {
                            // if the item is not a container display this message
                            Console.WriteLine("Why are you trying to open " + currentCommand.ToString());
                            return;
                        }
                        else if (currentLocation.getInventory()[i].name == currentCommand && !currentLocation.getInventory()[i].isAccessible)
                        {   
                            // if the item is not unlocked display this message
                            Console.WriteLine("You can't open it, maybe it's jammed or locked.");
                            return;
                        }
                        else if (currentLocation.getInventory()[i].name != currentCommand)
                        {
                            //if the item they want is not in the room display this message
                            Console.WriteLine("There is nothing here to open.");
                            return;
                        }


                    }
                }
                else
                {
                    Console.WriteLine("There is nothing in this room");
                    return;
                }
            }
            #endregion OpenCommand
            #region HelpCommand
            if (currentCommand == "help")
            {
                Console.WriteLine("Here are the commands you can enter:\n\"North\"\n\"South\"\n\"East\"\n\"West\"\n\"Down\"\n\"Up\"\n\"take\" \"(the item you want to take)\"\n\"Use\" \"(the item you want to use)\"\n\"Inventory\"\n\"Look\" - This lets you look at the current location again to see changes.\n\"Open\" \"(the item you want to open)\"\n\"Attack\"\n\"Check Health\"\n\"Drink Potion\"\n");
                return;
            }
            #endregion HelpCommand
            //looks at all exits and compares to current command if its the same then move to where it leads to
            #region MoveCommand
            foreach (Exit exit in currentLocation.getExits())
            {
                if (exit.ToString().ToLower() == currentCommand || exit.getShortDirection() == currentCommand)
                {
                    currentLocation = exit.getLeadsTo();
                    Console.Clear();
                    showLocation();
                    return;
                }
            }
            #endregion MoveCommand
            #region AttackCommand
            // if the player enters "attack" and there are enemies in the room do the following.
            if (currentCommand == "attack" && currentLocation.getEnemies().Count > 0 && playerInventory.getInventory().Count > 0)
            {
                //ask what the player wants to use then set that to chosen weapon
                Console.WriteLine("What do you want to attack with?");
                chosenWeapon = Console.ReadLine();
                //check the player has that item and if they do set the current weapon stats to that items stats
                for (int i = 0; i < playerInventory.getInventory().Count; i++)
                {
                    if (playerInventory.getInventory()[i].name == chosenWeapon)
                    {
                        SetWeaponStats();
                        //for every enemy, deal weapon damage, take damage from enemy, display damage dealt by both parties
                        for (int j = 0; j < currentLocation.getEnemies().Count; j++)
                        {
                            currentLocation.getEnemies()[j].health -= currentWeapon.damage;
                            playerHealth -= currentLocation.getEnemies()[j].damage;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nYou hit the " + currentLocation.getEnemies()[j].name.ToString() + " for " + currentWeapon.damage.ToString());
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nThe " + currentLocation.getEnemies()[j].name.ToString() + " hit you for " + currentLocation.getEnemies()[j].damage.ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                            //if the enemy loses all health, remove them
                            if (currentLocation.getEnemies()[j].health <= 0)
                            {
                                Console.WriteLine("\nYou have killed the " + currentLocation.getEnemies()[j].name);
                                if (currentLocation.getEnemies()[j].name == "Troll")
                                {
                                    l10.addExit(new Exit(Exit.Directions.West, l11));
                                }
                                currentLocation.removeEnemy(currentLocation.getEnemies()[j]);
                            }
                            //if player loses all health, disable input by setting dead true, clear console and write your are dead
                            if (playerHealth <= 0)
                            {
                                dead = true;
                                Console.Clear();
                                Console.WriteLine("You are dead.");

                            }
                        }
                    }
                    
                }
                return;
            }
            else if (currentCommand == "attack" && currentLocation.getEnemies().Count < 1)
            {
                Console.WriteLine("There are no enemies around.");
                return;
            }



            #endregion AttackCommand
            #region CheckHealthCommand
                if (currentCommand == "check health")
            {
                Console.WriteLine("\nYour current health is: " + playerHealth.ToString());
                return;
            }
            #endregion CheckHealthCommand
            #region DrinkCommand
                //if they enter this command check if they have a health potion if they do remove it and then add to player health, if not dispay message
            if (currentCommand == "drink potion")
            {
                for (int i = 0; i < playerInventory.getInventory().Count; i++)
                {
                    if (playerInventory.getInventory()[i].name == "Health Potion")
                    {
                        playerInventory.RemoveItem(healthPotion);
                        playerHealth += 5;
                        return;
                    }
                }
                Console.WriteLine("\nYou have no potions");
                return;
            }

            #endregion DrinkCommand
            doAction(currentCommand);
        }

        //adds a new location accessible after completeing a task in game
        public void AddL5()
        {

            l5.addExit(new Exit(Exit.Directions.South, l4));
            l4.addExit(new Exit(Exit.Directions.North, l5));
            
            l5.addItem(box);
            box.name = "box";
            box.isAccessible = true;
            box.canAdd = false;
            box.isContainer = true;

            return;
        }
        // this function will run when two valid items are being used, it will check to see if they match a valid coombination
        public void Use(String firstItem, String secondItem)
        {
            if (firstItem == "axe" && secondItem == ("door"))
            {
                Console.WriteLine("You bash down the door!");
                l4.removeItem(door);
                l4.setDescription("To the north you have knocked down the door");
                // currentLocation.removeItem(door);
                AddL5();
                return;
            }

      
            if (firstItem == "key" && secondItem == ("chest"))
            {
                Console.WriteLine("The key fits perfectly in the lock, you turn the key and hear a satisfying click. The chest is now unlocked.");
                chest.isAccessible = true;

                return;

            }
            if (firstItem == "rock" && secondItem == ("window"))
            {
                Console.WriteLine("You smash the window!");

                currentLocation.removeItem(window);

                l8.addExit(new Exit(Exit.Directions.East, l9));
                l8.setDescription("The log cabin has a small sturdy looking door on the front,\nwith the window you smashed to the right of it.");
                
                return;
            }
            if (firstItem == "rope" && secondItem == ("well"))
            {
                Console.WriteLine("You tie the rope to the top of the well and throw the rest down.");
                currentLocation.addExit(new Exit(Exit.Directions.Down, l10));
                Enemy troll = new Enemy("Troll", 9, 5);
                l10.addEnemy(troll);
                playerInventory.RemoveItem(rope);

                return;
            }
            else
            {
                Console.WriteLine("Nothing happens.");
            }

        }
        // if player is opening valid container run this to determine what is being opened and what should happen
        public void Open(String currentCommand)
        {
            if (currentCommand == "box" && !box.isEmpty)
            {
                Item key = new Item();
                key.name = "key";
                playerInventory.AddItem(key);
                Console.WriteLine("You found a key in the box!");
                box.isEmpty = true;
                return;
            }
            if (currentCommand == "chest" && !chest.isEmpty)
            {
                Console.WriteLine("You open the chest and find 3 Health Potions.");
                
                healthPotion.name = "Health Potion";
                playerInventory.AddItem(healthPotion);
                playerInventory.AddItem(healthPotion);
                playerInventory.AddItem(healthPotion);
                chest.isEmpty = true;
                return;
            }
           else
            {
                Console.WriteLine("This container is empty");
            }

        }
        //sets the current weapon damage stats to equal what item the player choses
        public void SetWeaponStats()
        {
            if (chosenWeapon == "axe")
            {
                currentWeapon.damage = axe.damage;
            }
            else if (chosenWeapon == "stick")
                {
                currentWeapon.damage = stick.damage;
                }
        }

    }
}
