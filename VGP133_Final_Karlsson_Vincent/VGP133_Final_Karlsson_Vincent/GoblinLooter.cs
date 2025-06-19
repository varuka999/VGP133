namespace VGP133_Final_Karlsson_Vincent
{
    internal class GoblinLooter : Monster
    {
        public GoblinLooter(Player player, string name, bool isBoss, int maxHP, int attack, int defense, int goldDropped) : base(player, name, isBoss, maxHP, attack, defense, goldDropped)
        {

        }

        protected override void UseSpecial(Unit target)
        {
            Console.WriteLine($"{Name} uses Weapon Snatch!");
            if (target.EquippedWeapon != null)
            {
                Console.WriteLine($"They stole {target.Name}'s weapon ({target.EquippedWeapon})!");
                EquipEquipment(target.EquippedWeapon);
                target.DropWeapon();
            }
            else
            {
                Console.WriteLine("But it failed!");
            }

            int damage = Attack + (EquippedWeapon?.AttBonus ?? 0);
            damage = Math.Max(damage, 1);

            Console.WriteLine($"{Name} is attacking {target.Name} for {damage}!");
            target.TakeDamage(damage);
        }
    }
}
