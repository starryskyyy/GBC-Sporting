namespace GBCSporting_Flip_Framework.Models
{
    public class IncidentEditViewModel
    {
        public Incident Incident { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }

        public string operation { get; set; }
    }
}
