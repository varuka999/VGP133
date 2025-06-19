namespace VGP133_Final_Karlsson_Vincent
{
    public class HealthPotion : Consumable
    {
        public HealthPotion() {}
        public HealthPotion(string name, int modifier, int cost) : base(name, modifier, cost)
        {

        }

        public override bool Use(Unit user)
        {
            user.AdjustCurrentHP(_modifierAmount);
            Console.WriteLine($"{user.Name} healed {_modifierAmount} health!");
            return true;
        }
    }
}
