using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Shop()
    {
        public List<ItemData> _consumableList = new List<ItemData>() { ItemData.HealthPotion, ItemData.AdvancedPotion, ItemData.SuperPotion };
        public List<ItemData> _equipmentList = new List<ItemData>() { ItemData.IronSword, ItemData.SteelSword, ItemData.LeatherArmor, ItemData.ToughArmor };

        public void ShopMenu(Player player, TownMenu shopType)
        {
            int itemInput;
            bool error = false;
            List<Item> shopItems = new List<Item>();

            if (shopType == TownMenu.Consumable)
            {
                foreach (var item in _consumableList)
                {
                    shopItems.Add(ItemDatabase.Create(item));
                }
            }
            else if (shopType == TownMenu.Equipment)
            {
                foreach (var item in _equipmentList)
                {
                    shopItems.Add(ItemDatabase.Create(item));
                }
            }

            while (true)
            {
                UI.RenderMenuHeader($"{shopType} Shop");
                UI.PlayerMenuBar(player);

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

                if (selectedItem is Consumable consumable)
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
