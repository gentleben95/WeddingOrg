using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.Domain.Entities
{
    public class Groom : Entity
    {
        [Required]
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Instagram { get; set; } = "";
        public bool IsSelected { get; set; }

    }
}
