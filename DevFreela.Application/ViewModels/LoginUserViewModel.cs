using System;
namespace DevFreela.Application.InputModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; set; }

        public string Email { get; set; }

    }
}
