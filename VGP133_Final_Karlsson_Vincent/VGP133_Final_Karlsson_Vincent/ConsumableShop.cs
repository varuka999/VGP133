namespace VGP133_Final_Karlsson_Vincent
{
    public struct ConsumableShop
    {
        public List<Item> consumableShopItems = new List<Item>();
    
        public ConsumableShop(ref Player player)
        {
            Consumable healthPotion1 = new HealthPotion(ref player, "Basic Health Potion", "", 10);
            Consumable healthPotion2 = new HealthPotion(ref player, "Advanced Health Potion", "", 25);
            Consumable healthPotion3 = new HealthPotion(ref player, "Super Health Potion", "", 50);
        }
    }
}
