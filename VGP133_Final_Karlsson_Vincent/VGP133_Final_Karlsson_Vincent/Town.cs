namespace VGP133_Final_Karlsson_Vincent
{
    public class Town
    {
        public void TownScene(Player player)
        {
            Console.Clear();
            UI.RenderMenuHeader("Town of Cenfelt");
            UI.PrintMenu<TownMenu>();
            int menuInput = Globals.GetMenuChoice<TownMenu>();

            switch ((TownMenu)menuInput)
            {
                case TownMenu.Inn:
                    player.AdjustCurrentHP(player.MaxHP);
                    Console.WriteLine("Visited the Inn and healed to full!");
                    break;
                case TownMenu.ConsumableShop:
                    Shop consumableShopInstance = new Shop();
                    consumableShopInstance.ShopMenu(player, TownMenu.ConsumableShop);
                    break;
                case TownMenu.EquipmentShop:
                    Shop equipmentShopInstance = new Shop();
                    equipmentShopInstance.ShopMenu(player, TownMenu.EquipmentShop);
                    break;
                case TownMenu.CheckInventory:
                    player.ShowInventoryMenu();
                    break;
                case TownMenu.CheckEquipment:
                    player.ShowEquipmentMenu();
                    break;
                case TownMenu.CheckCharacter:
                    player.DisplayStats();
                    break;
                case TownMenu.Exit:
                    return;
                default:
                    break;
            }
        }
    }
}
