namespace PharmacyWebApp.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}