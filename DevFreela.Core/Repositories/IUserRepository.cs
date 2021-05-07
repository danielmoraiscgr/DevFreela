﻿using System;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetUserByEmailAndPasswrodAsync(string email, string passwordHash);
    }
}
