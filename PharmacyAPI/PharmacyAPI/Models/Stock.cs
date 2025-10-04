namespace PharmacyAPI.Models
{
    public enum StockType
    {
        Internal,
        External
    }

    public class Stock
    {
        public int Id { get; set; }
        public string DrugName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string StockType { get; set; } = string.Empty; 

        // for external stock
        public string? SupplierName { get; set; }
        public DateTime? SupplierDate { get; set; }
        public string? CompanyName { get; set; }
    }
}