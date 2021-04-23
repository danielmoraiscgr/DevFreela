using System;
namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
