namespace PharmacyWebApp.Models
{
    public class DrugOrderModel
    {
        public int DrugID { get; set; } 
        public int Pharmacyid { get; set; }
        public int Quantity { get; set; }
    }
}