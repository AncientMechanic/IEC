using Domain.DTO;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Mvc;
using DTO = Domain.DTO;
using Domain.Views.Tasks;
using Domain.Extensions;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public sealed class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository, ILogger<TaskController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TaskView>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var view = entity.ConvertToView();
            return Ok(view);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DTO.Task>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();

            List<TaskView> views = new List<TaskView>();
            foreach (var entity in entities)
            {
                views.Add(new TaskView()
                {
                    Id = entity.Id,
                    ListId = entity.ListId,
                });
            }
            return Ok(views);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create(CreateTaskView view)
        {
            var model = view.ConvertToEntity();
            var id = await _repository.CreateAsync(model);

            return new ObjectResult(id) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(UpdateTaskView view)
        {
            var model = view.ConvertToEntity();
            await _repository.UpdateAsync(model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _repository.RemoveAsync(id);

            return NoContent();
        }
    }
}
