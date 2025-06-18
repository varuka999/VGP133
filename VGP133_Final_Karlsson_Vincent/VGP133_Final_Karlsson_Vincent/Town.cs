namespace VGP133_Final_Karlsson_Vincent
{
    public class Town
    {
        public void TownScene(Player player)
        {
            int menuInput = 0;

            Console.Clear();
            for (int i = 1; i < (int)TownMenu.Count; i++)
            {
                Console.WriteLine($"{i} - {(TownMenu?)Enum.GetValues(typeof(TownMenu)).GetValue(i)}");
            }
            //Console.WriteLine($"1 - {(TownMenu)Enum.GetValues(typeof(TownMenu)).GetValue(1)}\n2 - Consumable\n3 - Mountains\n4 - Boss Castle\nGo To:");

            while (menuInput == 0)
            {
                while (Int32.TryParse(Console.ReadLine(), out menuInput) == false)
                {
                    Globals.ClearConsoleLines(1);
                }

                if (Globals.ValidateIntInput(ref menuInput, (int)MainMenu.Count) == false)
                {
                    Globals.ClearConsoleLines(1);
                }
            }

            switch (menuInput)
            {
                case (int)TownMenu.Inn:
                    break;
                case (int)TownMenu.Consumable:
                    Shop consumableShopInstance = new Shop(player);
                    consumableShopInstance.ShopMenu(player, TownMenu.Consumable);
                    break;
                case (int)TownMenu.Equipment:
                    Shop equipmentShopInstance = new Shop(player);
                    equipmentShopInstance.ShopMenu(player, TownMenu.Equipment);
                    break;
                case (int)TownMenu.Character:
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
