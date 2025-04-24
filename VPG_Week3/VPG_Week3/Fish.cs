namespace VPG_Week3
{
    public abstract class Fish(string name) : Animal(name), ILife
    {
        //public string _name = name;

        public abstract void Swim();

        public abstract void Eat();

        public abstract void Reproduce();

        public abstract void Die();
    }
}
