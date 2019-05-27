namespace NFCCardEmulation.Application.Costs.Models
{
    public class CostDetailsModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int ShopId { get; set; }
        public int CardId { get; set; }

    }
}
