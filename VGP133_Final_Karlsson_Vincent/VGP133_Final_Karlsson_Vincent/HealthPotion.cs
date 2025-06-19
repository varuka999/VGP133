namespace VGP133_Final_Karlsson_Vincent
{
    public class HealthPotion : Consumable
    {
        //private event ConsumeDelegate OnHeal;

        public HealthPotion(string name, int modifier, int cost) : base(name, modifier, cost)
        {
            //OnHeal += player.AdjustCurrentHP;
            _description += $"Heals {_modifierAmount} health.";
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
