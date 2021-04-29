using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.DTOS;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAllAsync();
    }
}
