namespace VGP133_Final_Karlsson_Vincent
{
    public class Consumable : Item
    {
        protected int _modifierAmount;

        public Consumable(string name, string description, int modifier, int cost) : base(name, description, cost) 
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
