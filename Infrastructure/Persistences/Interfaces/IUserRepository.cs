using Domain.Entities;

namespace Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AccountByUserName(string userName);
    }
}
