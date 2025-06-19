using System.Xml.Linq;
using VGP133_Final_Karlsson_Vincent;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Monster : Unit
    {
        protected int _goldDrop;
        //protected List<Item> _lootTable = new List<Item>();

        public event Death1 DroppedGold;
        public event Death2 DroppedItems;

        public Monster(Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(name, maxHP, attack, defense)
        {
            Type = isBoss ? UnitType.Boss : UnitType.Monster;

            _goldDrop = goldDropped;

            DroppedGold += player.AddGold;
            DroppedItems += player.AddListOfItems;
        }

        public override void AttackTarget(Unit target)
        {
            Random random = new Random();

            if (random.NextDouble() <= 0.3)
            {
                UseSpecial(target);
            }
            else
            {
                base.AttackTarget(target);
            }
        }

        protected virtual void UseSpecial(Unit unit)
        {
            Console.WriteLine("Used Special Attack!")
;
        }

        //public override void TakeUnitDamage(Unit unit)
        //{
        //    base.TakeUnitDamage(unit);

        //    if (CurrentHP <= 0)
        //    {
        //        DroppedGold.Invoke(_goldDropped);
        //    }
        //}

        public override CombatResult OnDeath()
        {
            Console.WriteLine($"\nMonster ({Name}) Died");

            Console.WriteLine($"({Name}) dropped {_goldDrop} gold!");
            DroppedGold?.Invoke(_goldDrop);
            
            UnequipAllEquipment();
            if (_inventory.Count > 0)
            {
                Console.WriteLine($"({Name}) dropped some items!");
                DroppedItems?.Invoke(_inventory);
            }

            return base.OnDeath();
        }
    }
}

public delegate void Death1(int i);
public delegate void Death2(List<Item> i);
