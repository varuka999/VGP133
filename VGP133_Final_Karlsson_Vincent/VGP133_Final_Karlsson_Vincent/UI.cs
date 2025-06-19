namespace VGP133_Final_Karlsson_Vincent
{
    internal class UI
    {
        static string menuBarLine = "═══════════════════════════════════════════════";
        public static void RenderMenuHeader(string locationName)
        {
            Console.Clear();
            string gameTitle = "[ FANTASY ADVENTURE ]";
            string sceneLocation = $"'{locationName}'";
            Console.WriteLine(menuBarLine);
            Console.WriteLine(CenterText(gameTitle, menuBarLine.Length));
            Console.WriteLine(menuBarLine);
            Console.WriteLine(CenterText(sceneLocation, menuBarLine.Length));

            Console.WriteLine("───────────────────────────────────────────────");
        }

        public static void PrintMenu<T>() where T : Enum
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            for (int i = 1; i < enumValues.Count; i++)
            {
                Console.WriteLine($"{i} - {enumValues[i]}");
            }
        }

        public static void PlayerMenuBar(Player player)
        {
            string playerMenuBar = $"| {player.Name} | HP: {player.CurrentHP}/{player.MaxHP} | Gold: {player.Gold} |";
            Console.WriteLine(CenterText(playerMenuBar, menuBarLine.Length));
            string bottomLine = "";
            for (int i = 0; i < playerMenuBar.Length; ++i)
            {
                bottomLine += "─";
            }
            Console.WriteLine(CenterText(bottomLine, menuBarLine.Length));
        }

        public static void DisplayCombatScreen(Unit player, Unit monster, string locationName)
        {
            string sceneLocation = $"-----{locationName}-----";
            string combatBarLine = ("═══════════════════  COMBAT  ═══════════════════");

            Console.Clear();
            Console.WriteLine(menuBarLine);
            Console.WriteLine(CenterText(sceneLocation, combatBarLine.Length));
            Console.WriteLine($"     PLAYER{"",-26}ENEMY");
            Console.WriteLine(" ────────────────             ────────────────");

            Console.WriteLine($" Name: {player.Name,-24}Name: {monster.Name}");
            Console.WriteLine($" HP  : {player.CurrentHP}/{player.MaxHP,-20}HP  : {monster.CurrentHP}/{monster.MaxHP}");
            Console.WriteLine($" ATK : {player.Attack,-24}ATK : {monster.Attack}");
            Console.WriteLine($" DEF : {player.Defense,-24}DEF : {monster.Defense}");
            Console.WriteLine($" Weapon: {(player.EquippedWeapon?.Name ?? "None"),-22}Weapon: {(monster.EquippedWeapon?.Name ?? "None")}");
            Console.WriteLine($" Armor : {(player.EquippedArmor?.Name ?? "None"),-22}Armor : {(monster.EquippedArmor?.Name ?? "None")}");
            Console.WriteLine();

            Console.WriteLine("═══════════════  Combat Log  ═══════════════");
        }

        public static string CenterText(string text, int totalWidth)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                return "";
            }

            int padding = (totalWidth - text.Length) / 2;

            if (padding < 0)
            {
                padding = 0;
            }

            return new string(' ', padding) + text;
        }
    }
}
