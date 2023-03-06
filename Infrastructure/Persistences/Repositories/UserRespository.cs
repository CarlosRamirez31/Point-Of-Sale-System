using Domain.Entities;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistences.Repositories
{
    public class UserRespository : GenericRepository<User>, IUserRepository
    {
        private readonly PosContext _context;

        public UserRespository(PosContext context): base(context)
        {
            _context = context;
        }

        public async Task<User> AccountByUserName(string userName)
        {
            var account = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName!.Equals(userName));
            return account!;
        }
    }
}
