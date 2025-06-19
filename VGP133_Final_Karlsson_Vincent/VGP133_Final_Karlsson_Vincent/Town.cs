namespace VGP133_Final_Karlsson_Vincent
{
    public class Town
    {
        public void TownScene(Player player)
        {
            Console.Clear();
            Globals.PrintMenu<TownMenu>();
            int menuInput = Globals.GetMenuChoice<TownMenu>();

            switch ((TownMenu)menuInput)
            {
                case TownMenu.Inn:
                    player.AdjustCurrentHP(player.MaxHP);
                    Console.WriteLine("Visited the Inn and healed to full!");
                    break;
                case TownMenu.Consumable:
                    Shop consumableShopInstance = new Shop();
                    consumableShopInstance.ShopMenu(player, TownMenu.Consumable);
                    break;
                case TownMenu.Equipment:
                    Shop equipmentShopInstance = new Shop();
                    equipmentShopInstance.ShopMenu(player, TownMenu.Equipment);
                    break;
                case TownMenu.Character:
                    player.DisplayStats();
                    break;
                default:
                    break;
            }
        }

        public void RestAtInn(ref Player player)
        {

        }
    }
}
