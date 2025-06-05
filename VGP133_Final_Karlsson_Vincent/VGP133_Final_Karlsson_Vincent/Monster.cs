using System.Xml.Linq;

namespace VGP133_Final_Karlsson_Vincent
{
    public class Monster : Unit
    {
        protected int _goldDropped;
        protected List<Item> _lootTable = new List<Item>();

        public event Death1 DroppedGold;

        public Monster(ref Player player, string name, int maxHP, int attack, int defense, int goldDropped) : base(name, maxHP, attack, defense)
        {
            _goldDropped = goldDropped;

            DroppedGold += player.AddGold;
        }

        public void TakeDamage(ref Player unit)
        {
            int damage = unit.Attack - Defense;
            damage = Math.Max(damage, 1); // Ensures damage is at least 1

            Console.WriteLine($"{unit.Name} is attacking {Name} for {damage} damage ({Defense} blocked)!");
            CurrentHP -= damage;

            if (CurrentHP <= 0)
            {
                //unit.AddGold(_goldDropped);
                // Invoke Dropped Gold
                DroppedGold.Invoke(_goldDropped);
                // Invoke List of items (loot)
            }
        }

        //public override void TakeDamage(ref Unit unit)
        //{
        //    base.TakeDamage(ref unit);

        //    if (CurrentHP <= 0)
        //    {

        //    }
        //}

        //public void DropGold(int a)
        //{

        //}
    }
}

public delegate void Death1(int i);

//delegate void Death(int a); , Func<int> gold // try this later
