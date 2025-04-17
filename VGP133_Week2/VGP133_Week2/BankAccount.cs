namespace VGP133_Week2
{
    public class BankAccount
    {
        // Variables
        private string ownerName;
        private int balance;

        // Constructors
        public BankAccount()
        {
            this.ownerName = "";
            this.balance = 0;
        }

        public BankAccount(string ownerName, int balance)
        {
            this.ownerName = ownerName;
            this.balance = balance;
        }

        // Get/Set
        public string OwnderName { get => ownerName; set => ownerName = value; } // lambda
        public int Balance
        {
            get { return balance; }
            set
            {
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    Console.WriteLine("Balance cannot be less than 0!");
                }
            }
        }

        // Methods
        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
            }
        }

        public void PrintBalance()
        {
            Console.WriteLine(balance);
        }

        #region Test
        public int publicInt;

        private int privateInt;

        public int PrivateInt { get { return privateInt; } set { privateInt = value; } }

        public void Increment()
        {
            publicInt++;

            IncrementPrivate();
        }

        private void IncrementPrivate()
        {
            privateInt++;
        }
        #endregion
    }
}
