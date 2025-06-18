using System.Globalization;

namespace VGP133_Final_Karlsson_Vincent
{
    internal class Shop(Player player)
    {
        public List<Consumable> _consumableList = new List<Consumable>() { new HealthPotion(player, "Basic Health Potion", "", 10, 5),
                                                                           new HealthPotion(player, "Advanced Health Potion", "", 25, 10),
                                                                           new HealthPotion(player, "Super Health Potion", "", 50, 20) };

        public List<Equipment> _equipmentList = new List<Equipment>() { new Weapon("Sword1", 0, 5, 0, 5), new Weapon("Sword2", 0, 10, 0, 10), new Weapon("Sword3", 0, 15, -5, 15),
                                                                          new Armor("Armor1", 5, 0, 5, 5), new Armor("Armor2", 10, 0, 10, 10), new Armor("Armor3", 15, -10, 15, 15), };
        public void ShopMenu(Player player, TownMenu shopType)
        {
            int itemInput;

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

            Console.Clear();
            Console.WriteLine($"{shopType.ToString()} Shop!");
            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {shopItems[i].Name} ({shopItems[i].Cost}g)");
            }


        }
    }
}
