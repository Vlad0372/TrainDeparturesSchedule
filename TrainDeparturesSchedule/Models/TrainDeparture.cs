using System.ComponentModel.DataAnnotations;

namespace TrainDeparturesSchedule.Models
{
    public class TrainDeparture
    {
        [Key]
        public int Id { get; set; }
        public string Train { get; set; }
        public int Number { get; set; }
        public string Time { get; set; }
        public string Destination { get; set; }
        public string Remarks { get; set; }
    }
}
