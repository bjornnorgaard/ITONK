namespace Models
{
    public class SellOrder
    {
        public int SellerId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string TickerSymbol { get; set; }
    }
}
