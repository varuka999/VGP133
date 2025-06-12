namespace VGP133_Final_Karlsson_Vincent
{
    public class Town
    {
        public Town(ref Player player)
        {
            int menuInput = 0;

            Console.Clear();
            Console.WriteLine("1 - Town\n2 - Forest\n3 - Mountains\n4 - Boss Castle\nGo To:");

            while (menuInput == 0)
            {
                while (Int32.TryParse(Console.ReadLine(), out menuInput) == false)
                {
                    Globals.ClearConsoleLine();
                }

                if (Globals.ValidateIntInput(ref menuInput, (int)MainMenu.Count) == false)
                {
                    Globals.ClearConsoleLine();
                }
            }

            switch (menuInput)
            {
                case (int)TownMenu.Inn:
                    break;
                case (int)TownMenu.ConsumableShop:
                    break;
                case (int)TownMenu.EquipmentShop:
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
