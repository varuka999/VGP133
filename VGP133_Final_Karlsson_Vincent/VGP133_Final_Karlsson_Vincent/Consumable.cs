namespace VGP133_Final_Karlsson_Vincent
{
    public class Consumable : Item
    {
        protected int _modifierAmount;

        public Consumable(ref Player player, string name, string description, int modifier) : base(ref player, name, description) 
        {
            _modifierAmount = modifier;
        }

        public virtual void Consume()
        {
            Console.WriteLine($"Consumed {Name}!");
        }
    }

}
