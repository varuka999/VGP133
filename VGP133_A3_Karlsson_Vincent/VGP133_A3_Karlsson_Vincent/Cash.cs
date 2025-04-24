namespace VGP133_A3_Karlsson_Vincent
{
    internal class Cash(int paymentID, float paymentAmount) : PaymentMethod(paymentID, paymentAmount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("You used Cash!");
            Console.WriteLine($"Paid ${_paymentAmount} through Cash!\n");
        }
    }
}