namespace VGP133_Final_Karlsson_Vincent
{
    public static class ItemDatabase
    {
        public static Item Create(string name) // Consider changing to enums
        {
            return name switch
            {
                "HealthPotion" => new HealthPotion("Health Potion", 5, 5),
                "AdvancedPotion" => new HealthPotion("Advanced Potion", 10, 10),
                "SuperPotion" => new HealthPotion("Super Potion", 25, 20),
                "Elixir" => new HealthPotion("Elixer", 999, 100),
                "IronSword" => new Weapon("Iron Sword", 0, 5, 0, 20),
                "SteelSword" => new Weapon("Steel Sword", 0, 10, 0, 35),
                "DamascusSword" => new Weapon("Damascus Sword", 0, 15, 5, 55),
                "PiercingSword" => new Weapon("Piercing Sword", 0, 25, -5, 65),
                "LeatherArmor" => new Armor("Leather Armor", 0, 0, 5, 20),
                "ToughArmor" => new Armor("Tough Armor", 5, 0, 10, 35),
                "SpikedArmor" => new Armor("Spiked Armor", 5, 5, 5, 45),
                "ChainMailArmor" => new Armor("ChainMail Armor", 15, -5, 15, 60),
                _ => new HealthPotion("Health Potion", 5, 5),
            };
        }
    }
}
