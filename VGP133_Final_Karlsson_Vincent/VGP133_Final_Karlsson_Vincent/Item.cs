using System.Xml.Serialization;

namespace VGP133_Final_Karlsson_Vincent
{
    [Serializable]
    [XmlInclude(typeof(Consumable))]
    [XmlInclude(typeof(HealthPotion))]
    [XmlInclude(typeof(Equipment))]
    [XmlInclude(typeof(Armor))]
    [XmlInclude(typeof(Weapon))]
    public abstract class Item
    {
        protected string _name = "";
        protected int _cost;

        public string Name { get => _name; set => _name = value; }
        public int Cost { get => _cost; set => _cost = Math.Max(value, 1); }

        public Item() { }

        public Item(string name, int cost)
        {
            _name = name;
            _cost = cost;
        }

        public virtual bool Use(Unit user)
        {
            Console.WriteLine($"{user.Name} used {Name}!");
            return false;
        }

        public bool Equals(Item other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (other.Name == Name)
            {
                return true;
            }

            return false;
        }
    }
}
