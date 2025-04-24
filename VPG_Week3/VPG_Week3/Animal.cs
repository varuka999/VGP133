namespace VPG_Week3
{
    public abstract class Animal
    {
        protected string _name;

        public Animal(string name) 
        {
            _name = name;
        }

        public string Name { get { return _name; } }

        public virtual string MakeNoise()
        {
            return "????";
        }
    }
}
