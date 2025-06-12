namespace VGP133_Final_Karlsson_Vincent
{
    public class Forest
    {
        // Create Pool of monsters
        // 50/50 Fight chance. 
        // Player decides if they continue or go back to the overworld
        List<Monster> monsterPool = new List<Monster>();

        public Forest(ref Player player)
        {
            Monster enemy1 = new Monster(ref player, "TestForestMonster1", false, 20, 5, 1, 5);
            Monster enemy2 = new Monster(ref player, "TestForestMonster2", false, 20, 5, 1, 5);
            Monster enemy3 = new Monster(ref player, "TestForestMonster3", false, 20, 5, 1, 5);
            Monster enemy4 = new Monster(ref player, "TestForestMonster4", false, 20, 5, 1, 5);
            Monster enemy5 = new Monster(ref player, "TestForestMonster5", false, 20, 5, 1, 5);

            monsterPool.Add(enemy1);
            monsterPool.Add(enemy2);
            monsterPool.Add(enemy3);
            monsterPool.Add(enemy4);
            monsterPool.Add(enemy5);
        }

        public void RunForest(ref Player player)
        {
            List<Unit> units = new List<Unit>();
            Random random = new Random();

            units.Add(player);
            units.Add(monsterPool[random.Next(0, monsterPool.Count())]);

            //units[0].TakeRefUnitDamage(ref player);

            CombatManager combatInstance = new CombatManager();

            if (combatInstance.Combat(ref units))
            {
                // Continue exploring forest prompt
                Console.WriteLine("Continue exploring the forest?");
            }
            else
            {
                // Return to overworld
                Console.WriteLine("Returning to overworld..");
            }

        }
    }
}
