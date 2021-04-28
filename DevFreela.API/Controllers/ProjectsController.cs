using System;
using DevFreela.API.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.InputModels;
using MediatR;
using DevFreela.Application.Commands.CreateProject;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.FinishProject;

namespace DevFreela.API.Controllers
{
    
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
              
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
             _mediator = mediator; 
        }


        [HttpGet]
        public async Task<IActionResult> Get(string query)  
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)  
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }
                       
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command) 
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            var updateProjectCommand = new UpdateProjectCommand(id);

            await _mediator.Send(updateProjectCommand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)  
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {            
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var query = new StartProjectCommand(id);

            await _mediator.Send(query);

            return NoContent(); 
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var query = new FinishProjectCommand(id);

            await _mediator.Send(query);

            return NoContent(); 
        }

       
    }
}
