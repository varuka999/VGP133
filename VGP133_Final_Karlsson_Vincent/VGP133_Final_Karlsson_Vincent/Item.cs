namespace VGP133_Final_Karlsson_Vincent
{
    public abstract class Item
    {
        protected string _name;
        protected string _description;

        public string Name { get => _name; protected set => _name = value; }
        public string Description { get => _description; protected set => _description = value; }


        public Item(ref Player player, string name, string description)
        {
            Name = name;
            Description = description;
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
