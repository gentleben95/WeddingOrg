using System.Threading.Tasks;
using WeddingOrg.DTOs;
using WeddingOrg.Models;

namespace WeddingOrg.Repositories
{
    public interface IWeddingsRepository
    {
        //Task<Wedding>? GetWeddingsById(int id);
        Task<Wedding>? GetWeddingsById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Wedding>> GetWeddings(CancellationToken cancellationToken);
        Task<int> CreateWeedingBGPCR(UpdateWholeWeddingDto dto, CancellationToken cancellationToken);
        Task<int> DeleteWeddingById(int id, CancellationToken cancellationToken);
        Task<int> ChangeWeddingDates(int weddingId, UpdateWholeWeddingDto dto, CancellationToken cancellationToken);

        //void CreateWedding(string contractId);
        //void CreateBride(string brideName, string bridePhoneNumber, string brideEmail,
        //    string brideInstagram);
        //void CreateGroom(string groomName, string groomPhoneNumber, string groomEmail,
        //    string groomInstagram);
    }
}
