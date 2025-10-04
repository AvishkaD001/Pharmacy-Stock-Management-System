namespace SupplierWebApp.Models
{
    public class Tender
    {
        public int TenderId { get; set; }
        public int SupplierId { get; set; } 
        public string TenderDetails { get; set; } 
        public DateTime SubmissionDate { get; set; } 
    }
}