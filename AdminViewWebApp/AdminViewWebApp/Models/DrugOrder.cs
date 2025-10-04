namespace AdminViewWebApp.Models
{
    public class DrugOrder
    {
        public int DrugOrderId { get; set; }
        public int PharmacyId { get; set; }
        public int DrugID { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
