namespace VGP133_Final_Karlsson_Vincent
{
    internal class GoblinLooter : Monster
    {
        public GoblinLooter(Player player, bool isElite) : base(player, "Goblin Looter", false, isElite? 35 : 70, isElite ? 5 : 10, isElite ? 0 : 5, isElite ? 25 : 40)
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
