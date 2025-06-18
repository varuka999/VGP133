namespace VGP133_Final_Karlsson_Vincent
{
    public class Forest
    {
        // Create Pool of monsters
        // 50/50 Fight chance. 
        // Player decides if they continue or go back to the overworld
        List<Monster> monsterPool = new List<Monster>();

        public Forest(Player player)
        {
            Monster enemy1 = new Monster(player, "TestForestMonster1", false, 20, 5, 1, 5);
            Monster enemy2 = new Monster(player, "TestForestMonster2", false, 20, 5, 1, 5);
            Monster enemy3 = new Monster(player, "TestForestMonster3", false, 20, 5, 1, 5);
            Monster enemy4 = new Monster(player, "TestForestMonster4", false, 20, 5, 1, 5);
            Monster enemy5 = new Monster(player, "TestForestMonster5", false, 20, 5, 1, 5);

            monsterPool.Add(enemy1);
            monsterPool.Add(enemy2);
            monsterPool.Add(enemy3);
            monsterPool.Add(enemy4);
            monsterPool.Add(enemy5);
        }

        public void RunForest(Player player)
        {
            Console.Clear();

            List<Unit> units = new List<Unit>();
            Random random = new Random();

            units.Add(player);
            Monster tempMonster = new Monster(player, "", false, 0, 0, 0, 0);
            tempMonster = monsterPool[random.Next(0, monsterPool.Count())];
            units.Add(tempMonster);

            CombatManager combatInstance = new CombatManager();

            if (combatInstance.Combat(units))
            {
                // Continue exploring forest prompt
                Console.WriteLine("Continue exploring the forest?");
            }
            else
            {
                // Return to overworld
                Console.WriteLine("Returning to overworld..");
            }
            Console.ReadKey();
        }
    }
}
