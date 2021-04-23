using System;
namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now; 
        }

    }

    

}
