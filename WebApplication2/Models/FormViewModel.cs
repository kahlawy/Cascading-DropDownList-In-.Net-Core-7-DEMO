using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class FormViewModel
    {
        [DisplayName("City")]
        public int CityId { get; set; }
        public IEnumerable<City>? Cities { get; set;}

        [DisplayName("Area")]
        public int AreaId { get; set; }
        public IEnumerable<Area>? Areas { get; set; } = new List<Area>();
    }
}
