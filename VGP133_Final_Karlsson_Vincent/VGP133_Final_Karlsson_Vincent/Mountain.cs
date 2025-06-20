﻿namespace VGP133_Final_Karlsson_Vincent
{
    public class Mountain
    {
        private List<MonsterData> _monsterPoolNames;
        private List<ItemData> _itemPoolNames;

        public Mountain()
        {
            _monsterPoolNames = new List<MonsterData> { MonsterData.GoblinLooterB, MonsterData.ShaleGolemB, MonsterData.LargeLeechB, MonsterData.RecklessOgreB, MonsterData.ClumsyOgreB, MonsterData.PebbleBeastB };
            _itemPoolNames = new List<ItemData> { ItemData.AdvancedPotion, ItemData.SuperPotion, ItemData.Elixir, ItemData.SteelSword, ItemData.DamascusSword, ItemData.PiercingSword, ItemData.ToughArmor, ItemData.SpikedArmor, ItemData.ChainMailArmor };
        }

        public void Run(Player player)
        {
            UI.RenderMenuHeader("Mountain");
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
                CombatResult result = combatInstance.Combat(units, "Mountain");

                switch (result)
                {
                    case CombatResult.PlayerVictory:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou beat the monster!");
                        Console.ResetColor();
                        break;
                    case CombatResult.PlayerFlee:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nYou fled the battle.. ");
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

// Arthur was here (very nice game i enjoy) :)