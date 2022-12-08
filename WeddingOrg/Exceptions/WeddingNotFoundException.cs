using System.Runtime.Serialization;

namespace WeddingOrg.Exceptions
{
    [Serializable]
    internal class WeddingNotFoundException : Exception
    {
        public WeddingNotFoundException(string? message) : base(message)
        {

        }        
    }
}