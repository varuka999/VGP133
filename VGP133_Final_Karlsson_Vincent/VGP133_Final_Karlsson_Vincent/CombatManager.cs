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

        public CombatResult Combat(List<Unit> units) // Returns true if player exited combat safely, to determine exit sequence in previous 'scenes'
        {
            Random random = new Random();

            //int turns = 1;
            int attackingIndex = 0;
            int defendingIndex = 1;

            while (units[0].CurrentHP > 0 && units.Count > 1)
            {

                if (units[attackingIndex] is Player player) // If is Player class, declare 'player' as casted type
                {
                    PlayerAction action = player.PlayerCombatActions();
                    switch (action)
                    {
                        case PlayerAction.Attack:
                            player.AttackTarget(units[defendingIndex]);
                            break;
                        case PlayerAction.UseItem:
                            if (player.UseItemCombatAction(player) == false)
                            {
                                //Console.WriteLine("Failed to use item!");
                                continue;
                            }
                            break;
                        case PlayerAction.Flee:
                            return CombatResult.PlayerFlee;
                        default:
                            break;
                    }
                }
                else
                {
                    units[attackingIndex].AttackTarget(units[defendingIndex]);
                }

                if (units[defendingIndex].CurrentHP <= 0)
                {
                    CombatResult result = units[defendingIndex].OnDeath();
                    return result;
                }

                Globals.Pause();

                attackingIndex = 1 - attackingIndex;
                defendingIndex = 1 - defendingIndex;
            }

            return CombatResult.PlayerVictory;
        }

        //public delegate void OnDeath();
    }
}
