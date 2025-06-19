using System.Xml.Linq;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Monster : Unit
    {
        protected int _goldDrop;
        protected List<Item> _lootTable = new List<Item>();

        public event Death1 DroppedGold;

        public Monster(Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(name, maxHP, attack, defense)
        {
            Type = isBoss ? UnitType.Boss : UnitType.Monster;

            _goldDrop = goldDropped;

            DroppedGold += player.AddGold;
        }

        public override void AttackTarget(Unit target)
        {
            Random rnd = new Random();

            if (rnd.NextDouble() <= 0.3)
            {
                UseSpecial(target);
            }
            else
            {
                base.AttackTarget(target);
            }
        }

        private void UseSpecial(Unit unit)
        {
            Console.WriteLine("Used Special Attack!")
;        }

        //public override void TakeUnitDamage(Unit unit)
        //{
        //    base.TakeUnitDamage(unit);

        //    if (CurrentHP <= 0)
        //    {
        //        DroppedGold.Invoke(_goldDropped);
        //    }
        //}

        public override bool OnDeath()
        {
            Console.WriteLine($"MONSTER ({Name}) DIED");
            Console.WriteLine($"({Name}) dropped {_goldDrop} gold!");
            DroppedGold.Invoke(_goldDrop);

            return false;
        }
    }
}

public delegate void Death1(int i);
