namespace WeddingOrg.Application.Exceptions
{
    [Serializable]
    public class WeddingNotFoundException : Exception
    {
        public WeddingNotFoundException(string? message) : base(message)
        {

        }
    }
}