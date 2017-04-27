namespace requester.Models
{
    public class BuyOrder
    {
        public int BuyerId { get; set; }
        public string TickerSymbol { get; set; }
        public int MaxPrice { get; set; }
        public int Quantity { get; set; }
    }
}
