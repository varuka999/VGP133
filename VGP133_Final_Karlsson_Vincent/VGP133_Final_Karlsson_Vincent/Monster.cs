using System.Xml.Linq;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Monster : Unit
    {
        protected int _goldDropped;
        protected List<Item> _lootTable = new List<Item>();

        public event Death1 DroppedGold;

        public Monster(ref Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(name, maxHP, attack, defense)
        {
            Type = isBoss ? UnitType.Boss : UnitType.Monster;

            _goldDropped = goldDropped;

            DroppedGold += player.AddGold;
        }

        //public void TakeRefUnitDamage(ref Player unit)
        //{
        //    int damage = unit.Attack - Defense;
        //    damage = Math.Max(damage, 1); // Ensures damage is at least 1

        //    Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
        //    CurrentHP -= damage;

        //    if (CurrentHP <= 0)
        //    {
        //        //unit.AddGold(_goldDropped);
        //        // Invoke Dropped Gold
        //        DroppedGold.Invoke(_goldDropped);
        //        // Invoke List of items (loot)
        //    }
        //}

        //public override void TakeRefUnitDamage<T>(ref T unit)
        //{
        //    base.TakeRefUnitDamage(ref unit);

        //    //if (CurrentHP <= 0)
        //    //{
        //    //    //unit.AddGold(_goldDropped);
        //    //    // Invoke Dropped Gold
        //    //    DroppedGold.Invoke(_goldDropped);
        //    //    // Invoke List of items (loot)
        //    //}
        //}

        public override void TakeUnitDamage(Unit unit)
        {
            base.TakeUnitDamage(unit);

            if (CurrentHP <= 0)
            {
                DroppedGold.Invoke(_goldDropped);
            }
        }

        public override bool OnDeath()
        {
            Console.WriteLine($"MONSTER ({Name}) DIED");
            Console.WriteLine($"({Name}) dropped {_goldDropped} gold!");
            DroppedGold.Invoke(_goldDropped);

            return false;
        }

        //public void DropGold(int a)
        //{

        //}
    }
}

public delegate void Death1(int i);

//delegate void Death(int a); , Func<int> gold // try this later
