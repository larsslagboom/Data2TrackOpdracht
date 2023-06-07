using System.ComponentModel.DataAnnotations;

namespace Data2TrackApiOpdracht.Class
{
    public class PoiTypeAndTitle
    {
        [Key]
        public int PoiId { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
    }
}
