namespace VGP133_A3_Karlsson_Vincent
{
    internal class CreditCard(int paymentID, float paymentAmount) : PaymentMethod(paymentID, paymentAmount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("You used Credit!");
            Console.WriteLine($"Paid ${_paymentAmount} through credit!\n");
        }
    }
}
