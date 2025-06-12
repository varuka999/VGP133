namespace VGP133_Final_Karlsson_Vincent
{
    public class HealthPotion : Consumable
    {
        private event ConsumeDelegate OnHeal;

        public HealthPotion(ref Player player, string name, string description, int modifier, int cost) : base(name, description, modifier, cost)
        {
            OnHeal += player.HealHealth;
            Description += $"Heals {_modifierAmount} health.";
        }

        public override void Consume()
        {
            OnHeal.Invoke(_modifierAmount);
            base.Consume();
        }
    }

    delegate void ConsumeDelegate(int a);
}
