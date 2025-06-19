using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Shop()
    {
        public List<Consumable> _consumableList = new List<Consumable>() { new HealthPotion("Basic Health Potion", 10, 5),
                                                                           new HealthPotion("Advanced Health Potion", 25, 10),
                                                                           new HealthPotion("Super Health Potion", 50, 20) };

        public List<Equipment> _equipmentList = new List<Equipment>() { new Weapon("Sword1", 0, 5, 0, 5), new Weapon("Sword2", 0, 10, 0, 10), new Weapon("Sword3", 0, 15, -5, 15),
                                                                          new Armor("Armor1", 5, 0, 5, 5), new Armor("Armor2", 10, 0, 10, 10), new Armor("Armor3", 15, -10, 15, 15), };
        public void ShopMenu(Player player, TownMenu shopType)
        {
            int itemInput;
            bool error = false;
            List<Item> shopItems = new List<Item>();

            if (shopType == TownMenu.Consumable)
            {
                foreach (var item in _consumableList)
                {
                    shopItems.Add(item);
                }
            }
            else if (shopType == TownMenu.Equipment)
            {
                foreach (var item in _equipmentList)
                {
                    shopItems.Add(item);
                }
            }

            while (true)
            {
                UI.RenderMenuHeader($"{shopType.ToString()} Shop");
                UI.PlayerMenuBar(player);
                //Console.WriteLine($"{shopType.ToString()} Shop!");
                for (int i = 0; i < shopItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {shopItems[i].Name} ({shopItems[i].Cost}g)");
                }
                Console.WriteLine();

                while (true)
                {
                    Console.Write("Select an item (0 to leave shop): ");
                    if (int.TryParse(Console.ReadLine(), out itemInput) && Globals.ValidateIntInput(ref itemInput, 0, shopItems.Count + 1))
                    {
                        break;
                    }

                    Globals.ClearConsoleLinesBasedOnError(ref error);
                    Console.WriteLine("Invalid Input! Input a whole number corresponding to an item!");
                }

                if (itemInput == 0)
                {
                    return;
                }

                Item selectedItem = shopItems[itemInput - 1];

                if (player.Gold < selectedItem.Cost)
                {
                    Console.WriteLine("You don't have enough gold!");
                    Globals.Pause();
                    continue;
                }
                else
                {
                    player.AddGold(-selectedItem.Cost);
                    Console.WriteLine($"Bought {selectedItem.Name} for {selectedItem.Cost}g!");
                    Globals.Pause();
                }

                if (selectedItem is Consumable consumable) // So far only health potion as consumable, might add more types which will require updates here
                {
                    HealthPotion newItem = new HealthPotion(selectedItem.Name, ((HealthPotion)selectedItem).ModifierAmount, selectedItem.Cost);
                    player.AddItemToInventory(newItem);
                }
                else if (selectedItem is Equipment equipment)
                {
                    if (equipment is Weapon weapon)
                    {
                        player.AddItemToInventory(new Weapon(weapon.Name, weapon.HPBonus, weapon.AttBonus, weapon.DefBonus, weapon.Cost));
                    }
                    else if (equipment is Armor armor)
                    {
                        player.AddItemToInventory(new Armor(armor.Name, armor.HPBonus, armor.AttBonus, armor.DefBonus, armor.Cost));
                    }
                }
            }
        }
    }
}
