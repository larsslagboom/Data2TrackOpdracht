using System.ComponentModel.DataAnnotations;

namespace Data2TrackApiOpdracht.Class
{
    public class PoiLocation
    {
        [Key]
        public int PoiId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Radius { get; set; }
    }
}
