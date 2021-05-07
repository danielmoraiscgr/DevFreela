using System;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;

       // private readonly IUserRepository _userRepository; 

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
            //_userRepository = userRepository;

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
           // return await _userRepository.GetByIdAsync(id);
           
        }

        public async Task<User> GetUserByEmailAndPasswrodAsync(string email, string passwordHash)
        {
            var user = await _dbContext
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

            return user;
        }
    }
}
