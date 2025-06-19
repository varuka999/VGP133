using System.Numerics;

namespace VGP133_Final_Karlsson_Vincent
{
    public class CombatManager
    {
        public CombatResult Combat(List<Unit> units, string location) // Returns true if player exited combat safely, to determine exit sequence in previous 'scenes'
        {
            Random random = new Random();

            //int turns = 1;
            int attackingIndex = 0;
            int defendingIndex = 1;

            while (units[0].CurrentHP > 0 && units.Count > 1)
            {
                UI.DisplayCombatScreen(units[0], units[1], location);

                if (units[attackingIndex] is Player player) // If is Player class, declare 'player' as casted type
                {
                    PlayerAction action = player.PlayerCombatActions();
                    UI.DisplayCombatScreen(units[0], units[1], location);
                    switch (action)
                    {
                        case PlayerAction.Attack:
                            player.AttackTarget(units[defendingIndex]);
                            break;
                        case PlayerAction.UseItem:
                            if (player.UseItemCombatAction(player) == false)
                            {
                                Console.WriteLine("Failed to use item!");
                                Globals.Pause();
                                continue;
                            }
                            break;
                        case PlayerAction.Flee:
                            if (units[defendingIndex].Type == UnitType.Boss)
                            {
                                Console.WriteLine("Unable to flee form boss!");
                                Globals.Pause();
                                continue;
                            }
                            else
                            {
                                return CombatResult.PlayerFlee;
                            }
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
    }
}
