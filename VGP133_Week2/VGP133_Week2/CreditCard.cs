namespace VGP133_Week2
{
    internal class CreditCard
    {
        private string _name;
        private float _cashbackPercent;
        
        // Input cashback as whole number
        public CreditCard(string name, float cashbackPercent)
        {
            _name = name;
            _cashbackPercent = cashbackPercent / 100;
        }

        public void ComputeCashback(float amount)
        {
            Console.WriteLine($"From ${amount} spent you will get {amount * _cashbackPercent} cashback with {_name}\n");
        }
    }
}
