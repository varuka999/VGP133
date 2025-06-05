using System.Numerics;

namespace VGP133_Final_Karlsson_Vincent
{
    public class GameManager
    {
        private Player _player = null;
        private Town _town = null;

        public GameManager()
        {
            //_player = new Player("TestPlayer", "Brown", 'M', 20, 100, 100, 3);

            Test();

            //_town = new Town(ref _player);
        }

        // Test
        public void Test()
        {
            _player = new Player("TestPlayer", "Brown", 'M', 20, 100, 100, 3);
            Monster enemy = new Monster(ref _player, "TestEnemy", 20, 5, 1, 5);

            _player.TakeDamage(ref enemy);
            enemy.TakeDamage(ref _player);

            Consumable healthPotion1 = new HealthPotion(ref _player, "Basic Health Potion", "", 10);
            Consumable healthPotion2 = new HealthPotion(ref _player, "Advanced Health Potion", "", 25);
            Consumable healthPotion3 = new HealthPotion(ref _player, "Super Health Potion", "", 50);
            Consumable healthPotion4 = new HealthPotion(ref _player, "Basic Health Potion", "", 10);

            _player.AddConsumableToInventory(healthPotion1);
            _player.AddConsumableToInventory(healthPotion2);
            _player.AddConsumableToInventory(healthPotion3);
            _player.AddConsumableToInventory(healthPotion4);

            //_player.UseConsumable(healthPotion4);
            if (_player.UseConsumable("Basic Health Potion"))
            {
                Console.WriteLine("Item Use Success");
            }

            bool test = healthPotion1.Equals(healthPotion2);
        }

        public void Game()
        {
            bool gameRunning = true;

            while (gameRunning)
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
                    case (int)MainMenu.Town:
                        break;
                    case (int)MainMenu.Forest:
                        break;
                    case (int)MainMenu.Mountains:
                        break;
                    case (int)MainMenu.BossCastle:
                        break;
                    case (int)MainMenu.Inventory:
                        break;
                    case (int)MainMenu.Equipment:
                        break;
                    case (int)MainMenu.Save:
                        break;
                    case (int)MainMenu.Load:
                        break;
                    case (int)MainMenu.Exit: gameRunning = false;
                        break;
                    default:
                        break;
                }

            }


        }
    }
}
