namespace Models
{
    public class ChangeOwnershipObject
    {
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public int Quantity { get; set; }
        public string TickerSymbol { get; set; }
    }
}
