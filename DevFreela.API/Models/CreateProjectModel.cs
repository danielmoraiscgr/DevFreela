using System;
namespace DevFreela.API.Controllers
{
    public class CreateProjectModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public CreateProjectModel()
        {
        }
    }
}
