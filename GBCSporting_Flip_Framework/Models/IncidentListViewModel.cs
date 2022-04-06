namespace GBCSporting_Flip_Framework.Models
{
    public class IncidentListViewModel
    {
        public List<Incident> Incidents { get; set; }

        public string SelectedStatus { get; set; }
          

        // methods to help view determine active link
        public string CheckActiveStatus(string status) =>
            status == SelectedStatus ? "active" : "";
    }
}
