namespace VGP133_A3_Karlsson_Vincent
{
    internal interface IShoppingCart
    {
        public abstract void AddToCart(Product product);
        public abstract void RemoveFromCart(Product product);
        public abstract float CalculatePrice();
        public abstract void CheckOut(PaymentMethod paymentMethod);
    }
}
