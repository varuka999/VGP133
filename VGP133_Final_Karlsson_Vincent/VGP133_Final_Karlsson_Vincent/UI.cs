namespace VGP133_Final_Karlsson_Vincent
{
    internal class UI
    {
        public static void DisplayCombatStatus(Unit player, Unit enemy)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                 COMBAT                                 ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine($"{"PLAYER",-35}{"ENEMY",35}");
            Console.WriteLine("────────────────────────────────────────────────────────────────────────────");

            Console.WriteLine($"{player.Name,-35}{enemy.Name,35}");

            Console.WriteLine($"{($"HP: {player.CurrentHP}/{player.MaxHP}", -35)}{($"HP: {enemy.CurrentHP}/{enemy.MaxHP}", 35)}");
            Console.WriteLine($"{($"ATK: {player.Attack}", -35)}{($"ATK: {enemy.Attack}", 35)}");
            Console.WriteLine($"{($"DEF: {player.Defense}", -35)}{($"DEF: {enemy.Defense}", 35)}");

            if (player.EquippedWeapon != null || enemy.EquippedWeapon != null)
            {
                Console.WriteLine();
                Console.WriteLine($"{($"Weapon: {player.EquippedWeapon?.Name ?? "None"}", -35)}{($"Weapon: {enemy.EquippedWeapon?.Name ?? "None"}", 35)}");
            }

            if (player.EquippedArmor != null || enemy.EquippedArmor != null)
            {
                Console.WriteLine($"{($"Armor: {player.EquippedArmor?.Name ?? "None"}", -35)}{($"Armor: {enemy.EquippedArmor?.Name ?? "None"}", 35)}");
            }

            Console.WriteLine("\n────────────────────────────────────────────────────────────────────────────\n");
        }

        public static void DisplayCombatScreen(Unit player, Unit monster)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════  COMBAT  ═══════════════════");
            Console.WriteLine();

            // Left: Player | Right: Enemy
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
            //foreach (var entry in log)
            //    Console.WriteLine($"> {entry}");

            //Console.WriteLine("\n═══════════════════════════════════════════════");
            //Console.WriteLine(" Press any key to continue...");
            //Console.ReadKey();
        }

        public void DisplayUnitStatus(Unit unit, string label)
        {
            Console.WriteLine($" {label,-8} Name: {unit.Name}");
            Console.WriteLine($" {"",-8} HP  : {unit.CurrentHP} / {unit.MaxHP}");
            Console.WriteLine($" {"",-8} ATK : {unit.Attack}");
            Console.WriteLine($" {"",-8} DEF : {unit.Defense}");
            Console.WriteLine($" {"",-8} Weapon: {(unit.EquippedWeapon != null ? unit.EquippedWeapon.Name : "None")}");
            Console.WriteLine($" {"",-8} Armor : {(unit.EquippedArmor != null ? unit.EquippedArmor.Name : "None")}");
        }
    }
}
