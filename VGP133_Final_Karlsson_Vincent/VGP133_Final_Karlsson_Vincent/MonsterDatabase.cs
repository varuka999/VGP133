using System.Drawing;

namespace VGP133_Final_Karlsson_Vincent
{
    internal class MonsterDatabase
    {
        public static Monster Create(string name, Player player) // Consider changing to enum
        {
            return name switch // Personal note, this return switch is really cool
            {
                "GoblinLooterA" => new GoblinLooter(player, false),
                "GoblinLooterB" => new GoblinLooter(player, true),
                "ShaleGolemA" => new ShaleGolem(player, false),
                "ShaleGolemB" => new ShaleGolem(player, true),
                "LargeLeechA" => new LargeLeech(player, false),
                "LargeLeechB" => new LargeLeech(player, true),
                _ => new Monster(player, "Unknown", false, 10, 2, 0, 1) // No match, though shouldn't happen
            };
        }
    }
}
