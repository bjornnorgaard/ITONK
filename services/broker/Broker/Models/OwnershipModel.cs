namespace Models
{
    public class OwnershipModel
    {
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public int Quantity { get; set; }
        public string TickerSymbol { get; set; }
    }
}
