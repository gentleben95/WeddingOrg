using System.ComponentModel.DataAnnotations;

namespace WeddingOrg.Domain.Entities
{
    public class Wedding : Entity
    {
        public string DateOfTheWedding { get; set; }
        public string DateOfSigningTheContract { get; set; }
        public Bride Bride { get; set; } = new();
        public Groom Groom { get; set; } = new();
        public Photographer? Photographer { get; set; }
        public Cameraman? Cameraman { get; set; }
        public Restaurant? Restaurant { get; set; }
        public bool IsSelected { get; set; }
    }
}
