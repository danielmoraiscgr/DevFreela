using System;
using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);

        int Create(NewUserInputModel inputModel);

        LoginUserViewModel Login(string email, string password);


    }
}
