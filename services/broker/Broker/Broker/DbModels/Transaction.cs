namespace Broker.DbModels
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BuyRecordId { get; set; }
        public int SellRecordId { get; set; }
    }
}
