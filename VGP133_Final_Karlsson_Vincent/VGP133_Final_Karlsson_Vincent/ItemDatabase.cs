namespace VGP133_Final_Karlsson_Vincent
{
    public static class ItemDatabase
    {
        public static Item? Create(string name)
        {
            switch (name)
            {
                case "Basic Health Potion":
                    return new HealthPotion("Basic Health Potion", 10, 5);
                default:
                    Console.WriteLine("ItemDatabase: Couldn't make item!");
                    return null;
            }
        }
    }
}
