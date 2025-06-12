using System.Numerics;

namespace VGP133_Final_Karlsson_Vincent
{
    public class CombatManager
    {
        //private event OnDeath? OnDeathEvent; // UNUSED CURRENTLY, INCORRECT THOUGHT PROCESS

        public CombatManager()
        {
            //foreach (Unit unit in units)
            //{
            //    OnDeathEvent += unit.OnDeath; // UNUSED CURRENTLY, INCORRECT THOUGHT PROCESS
            //}
        }

        // Takes list of units, correctly distributes based on type
        // simulates battle

        public bool Combat(ref List<Unit> units) // Returns true if player exited combat safely, to determine exit sequence in previous 'scenes'
        {
            // Imported List assumes correct ordering (units[0] is always the player)
            //List<Unit> units = new List<Unit>();
            //units.Add(player);
            //units.Add(monster);

            Random random = new Random();

            //int turns = 1;
            int attackingIndex = 0;
            int defendingIndex = 1;

            while (units[0].CurrentHP > 0 && units.Count > 1)
            {


                units[defendingIndex].TakeUnitDamage(units[attackingIndex]);

                if (units[defendingIndex].CurrentHP <= 0) 
                {
                    //units.RemoveAt(defendingIndex);
                    bool isPlayerDead = units[defendingIndex].OnDeath();
                    return !isPlayerDead;
                }

                // Swap attackers/defenders (temp for 1v1)
                attackingIndex = 1 - attackingIndex;
                defendingIndex = 1 - defendingIndex;
            }

            return true;
        }


        //public delegate void OnDeath();
    }
}
