namespace VGP133_Final_Karlsson_Vincent
{
    public class Forest
    {
        // Create Pool of monsters
        // 50/50 Fight chance. 
        // Player decides if they continue or go back to the overworld
        //List<Monster> monsterPool = new List<Monster>();

        private List<string> _monsterPoolNames;
        private List<string> _itemPoolNames;

        public Forest()
        {
            _monsterPoolNames = new List<string> { "LooterGoblinA", "ShaleGolemA", "LargeLeechA" };
            _itemPoolNames = new List<string> { "HealthPotion", "AdvancedHealthPotion", "SuperHealthPotion", "IronSword", "LeatherArmor", "SteelSword", "ToughArmor" };
        }

        //public Forest(Player player)
        //{
        //    Monster enemy1 = new Monster(player, "TestForestMonster1", false, 20, 5, 1, 5);
        //    Monster enemy2 = new Monster(player, "TestForestMonster2", false, 20, 5, 1, 5);
        //    Monster enemy3 = new Monster(player, "TestForestMonster3", false, 20, 5, 1, 5);
        //    Monster enemy4 = new Monster(player, "TestForestMonster4", false, 20, 5, 1, 5);
        //    Monster enemy5 = new Monster(player, "TestForestMonster5", false, 20, 5, 1, 5);

            //    monsterPool.Add(enemy1);
            //    monsterPool.Add(enemy2);
            //    monsterPool.Add(enemy3);
            //    monsterPool.Add(enemy4);
            //    monsterPool.Add(enemy5);
            //}

        public void RunForest(Player player)
        {
            Console.Clear();
            Random random = new Random();

            if (random.NextDouble() <= 0.5)
            {
                string rewardName = _itemPoolNames[random.Next(_itemPoolNames.Count)];
                Item reward = ItemDatabase.Create(rewardName);

                Console.WriteLine($"You found a {reward.Name}!");
                player.AddItemToInventory(reward);
            }
            else
            {
                List<Unit> units = new List<Unit>();

                //Monster tempMonster = new Monster(player, "", false, 0, 0, 0, 0);
                //tempMonster = monsterPool[random.Next(0, monsterPool.Count())];
                //units.Add(tempMonster);

                string monsterName = _monsterPoolNames[random.Next(_monsterPoolNames.Count)];
                Monster enemy = MonsterDatabase.Create(monsterName, player);
                units.Add(player);
                units.Add(enemy);

                CombatManager combatInstance = new CombatManager();
                CombatResult result = combatInstance.Combat(units);

                switch (result)
                {
                    case CombatResult.PlayerVictory:
                        Console.WriteLine("You beat the monster!");
                        break;
                    case CombatResult.PlayerFlee:
                        Console.WriteLine("You fled the battle.");
                        break;
                    case CombatResult.PlayerDefeat:
                        Console.WriteLine("You were defeated...");
                        break;
                }
            }

            //Globals.Pause();
        }
    }
}
