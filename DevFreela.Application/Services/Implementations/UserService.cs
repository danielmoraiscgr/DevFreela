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

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.Password, inputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;

        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
                       
            if (user == null)
            {
                return null;
            }

            var userViewModel = new UserViewModel(user.Id, user.FullName, user.Email);

            return userViewModel;

        }

        public LoginUserViewModel Login(string email, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            var loginUserViewModel = new LoginUserViewModel(user.FullName, user.Email);

            return loginUserViewModel;
            
        }
    }
}
