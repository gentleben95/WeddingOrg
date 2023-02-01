using System.ComponentModel.DataAnnotations;
using WeddingOrg.Common;
namespace WeddingOrg.Models
{
    public class Photographer : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Facebook { get; set; } = "";
        public string Instagram { get; set; } = "";
        public bool IsSelected { get; set; }
    }
}
