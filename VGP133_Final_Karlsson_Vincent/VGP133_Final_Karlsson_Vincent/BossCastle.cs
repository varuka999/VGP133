namespace VGP133_Final_Karlsson_Vincent
{
    internal class BossCastle
    {
        private List<MonsterData> _monsterPoolNames;
        private List<ItemData> _itemPoolNames;

        public BossCastle()
        {
            _monsterPoolNames = new List<MonsterData> { MonsterData.GoblinLooterB, MonsterData.ShaleGolemB, MonsterData.LargeLeechB, MonsterData.RecklessOgreB, MonsterData.ClumsyOgreB, MonsterData.PebbleBeastB };
            _itemPoolNames = new List<ItemData> { ItemData.AdvancedPotion, ItemData.SuperPotion, ItemData.Elixir, ItemData.SteelSword, ItemData.DamascusSword, ItemData.PiercingSword, ItemData.ToughArmor, ItemData.SpikedArmor, ItemData.ChainMailArmor };
        }

        public bool Run(Player player)
        {
            UI.RenderMenuHeader("Boss Castle");
            Random random = new Random();

            // Combat 1
            List<Unit> units = new List<Unit>();

            MonsterData monsterName = _monsterPoolNames[random.Next(_monsterPoolNames.Count)];
            Monster enemy = MonsterDatabase.Create(monsterName, player);

            units.Add(player);
            units.Add(enemy);

            CombatManager combatInstance = new CombatManager();
            CombatResult result = combatInstance.Combat(units, "Boss Castle Room 1");

            if (result == CombatResult.PlayerFlee)
            {
                Console.WriteLine("You fled the battle..");
                return false;
            }
            else if (result == CombatResult.PlayerDefeat)
            {
                Console.WriteLine("You were defeated...");
                return false;
            }

            // Combat 2
            units = new List<Unit>();
            monsterName = _monsterPoolNames[random.Next(_monsterPoolNames.Count)];
            enemy = MonsterDatabase.Create(monsterName, player);

            units.Add(player);
            units.Add(enemy);

            combatInstance = new CombatManager();
            result = combatInstance.Combat(units, "Boss Castle Room 2");

            if (result == CombatResult.PlayerFlee)
            {
                Console.WriteLine("You fled the battle..");
                return false;
            }
            else if (result == CombatResult.PlayerDefeat)
            {
                Console.WriteLine("You were defeated...");
                return false;
            }

            // Final Combat
            units = new List<Unit>();
            enemy = MonsterDatabase.Create(MonsterData.Boss, player);

            units.Add(player);
            units.Add(enemy);

            combatInstance = new CombatManager();
            result = combatInstance.Combat(units, "Boss Castle Chambers");

            if (result == CombatResult.PlayerVictory)
            {
                Console.WriteLine("\n---You defeated the boss! You beat the game!---\n");
                return true;
            }
            else
            {
                Console.WriteLine("You were defeated...");
                return false;
            }
        }
    }
}
