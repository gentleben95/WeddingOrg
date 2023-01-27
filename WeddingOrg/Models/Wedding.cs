using System.ComponentModel.DataAnnotations;
using WeddingOrg.Common;

namespace WeddingOrg.Models
{
    public class Wedding : Entity
    {
        public string DateOfTheWedding { get; set; }
        public string DateOfSigningTheContract { get; set; }
        public Bride? Bride { get; set; } = new();
        public Groom? Groom { get; set; } = new();   
        public Photographer? Photographer { get; set; } = new();
        public Cameraman? Cameraman { get; set; } = new();
        public Restaurant? Restaurant { get; set; } = new();
    }
}
