namespace VGP133_A3_Karlsson_Vincent
{
    internal abstract class PaymentMethod(int paymentID, float paymentAmount)
    {
        protected int _paymentID = paymentID;
        protected float _paymentAmount = paymentAmount;

        public abstract void ProcessPayment();
    }
}
