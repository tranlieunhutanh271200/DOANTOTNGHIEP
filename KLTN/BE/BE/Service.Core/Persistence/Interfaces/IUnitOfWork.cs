using System.Threading.Tasks;

namespace Service.Core.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        R GetRequiredRepository<I, R>();
        void CreateTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
