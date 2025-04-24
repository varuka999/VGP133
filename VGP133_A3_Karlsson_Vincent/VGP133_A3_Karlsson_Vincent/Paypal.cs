namespace VGP133_A3_Karlsson_Vincent
{
    internal class PayPal(int paymentID, float paymentAmount) : PaymentMethod(paymentID, paymentAmount)
    {
        public override void ProcessPayment()
        {
            Console.WriteLine("You used PayPal!");
            Console.WriteLine($"Paid ${_paymentAmount} through PayPal!\n");
        }
    }
}