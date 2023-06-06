using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.Domain.Entities
{
    public class Cameraman : Entity
    {
        
        [Required]
        public string Name { get; set; }
        public string Facebook { get; set; } = "";
        public string Instagram { get; set; } = "";
        public bool IsSelected { get; set; }
    }
}
