using Domain.DTO;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Domain.Views.Participants;
using Domain.Extensions;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public sealed class ParticipantController : ControllerBase
    {
        private readonly ILogger<ParticipantController> _logger;
        private readonly IParticipantRepository _repository;

        public ParticipantController(IParticipantRepository repository, ILogger<ParticipantController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ParticipantView>> GetById(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            var view = entity.ConvertToView();
            return Ok(view);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Participant>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();

            List<ParticipantView> views = new List<ParticipantView>();
            foreach (var entity in entities)
            {
                views.Add(new ParticipantView()
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Patronymic = entity.Patronymic,
                    NameOfUniversity = entity.NameOfUniversity,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                });
            }
            return Ok(views);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create(CreateParticipantView view)
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
        public async Task<ActionResult> Update(UpdateParticipantView view)
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
