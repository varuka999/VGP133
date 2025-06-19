namespace VGP133_Final_Karlsson_Vincent
{
    public class Forest
    {
        private List<MonsterData> _monsterPoolNames;
        private List<ItemData> _itemPoolNames;

        public Forest()
        {
            _monsterPoolNames = new List<MonsterData> { MonsterData.GoblinLooterA, MonsterData.ShaleGolemA, MonsterData.LargeLeechA, MonsterData.RecklessOgreA, MonsterData.ClumsyOgreA, MonsterData.PebbleBeastA};
            _itemPoolNames = new List<ItemData> { ItemData.HealthPotion, ItemData.AdvancedPotion, ItemData.SuperPotion, ItemData.IronSword, ItemData.SteelSword, ItemData.LeatherArmor, ItemData.ToughArmor };
        }

        public void Run(Player player)
        {
            UI.RenderMenuHeader("Forest");
            Random random = new Random();

            if (random.NextDouble() <= 0.5)
            {
                ItemData rewardName = _itemPoolNames[random.Next(_itemPoolNames.Count)];
                Item reward = ItemDatabase.Create(rewardName);

                Console.WriteLine($"You found a {reward.Name}!");
                player.AddItemToInventory(reward);
            }
            else
            {
                List<Unit> units = new List<Unit>();

                MonsterData monsterName = _monsterPoolNames[random.Next(_monsterPoolNames.Count)];
                Monster enemy = MonsterDatabase.Create(monsterName, player);

                units.Add(player);
                units.Add(enemy);

                CombatManager combatInstance = new CombatManager();
                CombatResult result = combatInstance.Combat(units, "Forest");

                switch (result)
                {
                    case CombatResult.PlayerVictory:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou beat the monster!");
                        Console.ResetColor();
                        break;
                    case CombatResult.PlayerFlee:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYou fled the battle..");
                        Console.ResetColor();
                        break;
                    case CombatResult.PlayerDefeat:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou were defeated...");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
