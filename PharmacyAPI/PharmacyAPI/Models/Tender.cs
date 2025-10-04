namespace PharmacyAPI.Models
{
    public class Tender
    {
        public int TenderId { get; set; }
        public string CompanyRegistrationId { get; set; }
        public string TenderDetails { get; set; }
        public DateTime SubmissionDate { get; set; }

    }

}
