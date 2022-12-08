using System.ComponentModel.DataAnnotations;
using WeddingOrg.Common;
namespace WeddingOrg.Models
{
    public class Bride : Entity
    {
        [Required]
        public string Name { get; set; } = "";
        public string PhoneNumber  { get; set; } = "";
        public string Email { get; set; } = "";
        public string Instagram { get; set; } = "";
    }
}
