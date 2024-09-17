
namespace GlameraTask.Domain.Models
{
    public class Service
    {
        [Key]
        public int? ServiceId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Duration { get; set; }
    }
}
