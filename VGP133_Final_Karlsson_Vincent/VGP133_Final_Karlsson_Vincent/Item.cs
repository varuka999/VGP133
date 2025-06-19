namespace VGP133_Final_Karlsson_Vincent
{
    public abstract class Item
    {
        protected string _name = "";
        protected string _description = "";
        protected int _cost;

        public string Name { get => _name; }
        public string Description { get => _description; }
        public int Cost { get => _cost; protected set => _cost = Math.Max(value, 1); }

        public Item(string name, int cost)
        {
            _name = name;
            _description = "";
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
