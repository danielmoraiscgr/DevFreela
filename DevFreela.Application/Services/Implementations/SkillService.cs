using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _coonectionString;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _coonectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            // Implementando o Dapper
            using (var sqlConnection = new SqlConnection(_coonectionString))
            {
                sqlConnection.Open();

                var script = "Select Id, Description from Skills";

                return sqlConnection.Query<SkillViewModel>(script).ToList();
            }

            //var skills = _dbContext.Skills;

            //var skillsViewModel = skills
            //    .Select(s => new SkillViewModel(s.Id, s.Description))
            //    .ToList();

            //return skillsViewModel;
              
        }
    }
}
