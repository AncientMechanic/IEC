using Domain.DTO;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Domain.Views.Lists;
using Domain.Extensions;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public sealed class ListController : ControllerBase
    {
        private readonly ILogger<ListController> _logger;
        private readonly IListRepository _repository;

        public ListController(IListRepository repository, ILogger<ListController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListView>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var view = entity.ConvertToView();
            return Ok(view);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<List>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();

            List<ListView> views = new List<ListView>();
            foreach (var entity in entities)
            {
                views.Add(new ListView()
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Name = entity.Name,
                });
            }
            return Ok(views);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create(CreateListView view)
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
        public async Task<ActionResult> Update(UpdateListView view)
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
