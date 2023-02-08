namespace WeddingOrg.Domain.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
    }
}
