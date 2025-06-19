namespace VGP133_Final_Karlsson_Vincent
{
    public static class ItemDatabase
    {
        public static Item Create(ItemData name) // Consider changing to enums
        {
            return name switch
            {
                ItemData.HealthPotion => new HealthPotion("Health Potion", 5, 5),
                ItemData.AdvancedPotion => new HealthPotion("Advanced Potion", 10, 10),
                ItemData.SuperPotion => new HealthPotion("Super Potion", 25, 20),
                ItemData.Elixir => new HealthPotion("Elixer", 999, 100),
                ItemData.IronSword => new Weapon("Iron Sword", 0, 5, 0, 20),
                ItemData.SteelSword => new Weapon("Steel Sword", 0, 10, 0, 35),
                ItemData.DamascusSword => new Weapon("Damascus Sword", 0, 15, 5, 55),
                ItemData.PiercingSword => new Weapon("Piercing Sword", 0, 25, -5, 65),
                ItemData.LeatherArmor => new Armor("Leather Armor", 0, 0, 5, 20),
                ItemData.ToughArmor => new Armor("Tough Armor", 5, 0, 10, 35),
                ItemData.SpikedArmor => new Armor("Spiked Armor", 5, 5, 5, 45),
                ItemData.ChainMailArmor => new Armor("ChainMail Armor", 15, -5, 15, 60),
                _ => new HealthPotion("Health Potion", 5, 5),
            };
        }
    }
}
