namespace VGP133_Final_Karlsson_Vincent
{
    [Serializable]
    public class Consumable : Item
    {
        protected int _modifierAmount;

        public int ModifierAmount { get => _modifierAmount; set => _modifierAmount = value; }

        public Consumable() {}
        public Consumable(string name, int modifier, int cost) : base(name, cost) 
        {
            _modifierAmount = modifier;
        }

        public override bool Use(Unit user)
        {
            return false;
        }

        public virtual void Consume()
        {
            Console.WriteLine($"Consumed {Name}!");
        }
    }
}
