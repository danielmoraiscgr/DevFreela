using System;
using System.Linq;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
               
        public LoginUserViewModel Login(string email, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            var loginUserViewModel = new LoginUserViewModel(user.FullName, user.Email);

            return loginUserViewModel;
            
        }
    }
}
