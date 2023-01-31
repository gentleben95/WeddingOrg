using WeddingOrg.Common;
namespace WeddingOrg.Models
{
    public class Cameraman : Entity 
    {
        public string Facebook { get; set; } = "";
        public string Instagram { get; set; } = "";
        public List<Wedding> Weddings { get; set; } = new();
    }
}
