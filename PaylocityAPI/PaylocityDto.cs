using System.ComponentModel.DataAnnotations;

namespace PaylocityAPI
{
    public class PaylocityDto
    {
        [StringLength(30)]
        public string name { get; set; }

        [StringLength(30)]
        public string type { get; set; }

        [StringLength(50)]
        public string description { get; set; }
        public DateOnly date { get; set; }
    }
}
