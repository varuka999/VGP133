namespace VGP133_Final_Karlsson_Vincent
{
    public class HealthPotion : Consumable
    {
        //private event ConsumeDelegate OnHeal;

        public HealthPotion(Player player, string name, string description, int modifier, int cost) : base(name, description, modifier, cost)
        {
            //OnHeal += player.AdjustCurrentHP;
            Description += $"Heals {_modifierAmount} health.";
        }

        public override bool Use(Unit user)
        {
            user.AdjustCurrentHP(_modifierAmount);
            Console.WriteLine($"{user.Name} healed {_modifierAmount} health!");
            return true;
        }

        //public override void Consume()
        //{
        //    OnHeal.Invoke(_modifierAmount);
        //    base.Consume();
        //}
    }

    //delegate void ConsumeDelegate(int a);
}
