using System.ComponentModel.DataAnnotations;

namespace PaylocityModels
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

        public override string ToString()
        {
            return string.Format($"name: {name},\n" +
                $"type: {type},\n" +
                $"description: {description},\n" +
                $"date: {date}\n");
        }
    }
}
