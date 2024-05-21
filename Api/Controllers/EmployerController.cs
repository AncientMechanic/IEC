using Domain.DTO;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Mvc;
using DTO = Domain.DTO;
using Domain.Views.Employers;
using Domain.Extensions;

namespace Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public sealed class EmployerController : ControllerBase
    {
        private readonly ILogger<EmployerController> _logger;
        private readonly IEmployerRepository _repository;

        public EmployerController(IEmployerRepository repository, ILogger<EmployerController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{participantid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployerView>> GetById(Guid participantid)
        {
            var entity = await _repository.GetByParticipantIdAsync(participantid);

            var view = entity.ConvertToView();
            return Ok(view);
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DTO.Employer>>> GetAll()
        {
            var entities = await _repository.GetAllAsync();

            List<EmployerView> views = new List<EmployerView>();
            foreach (var entity in entities)
            {
                views.Add(new EmployerView()
                {
                    Id = entity.Id,
                    ParticipantId = entity.ParticipantId,
                    CompanyName = entity.CompanyName,
                    ContactFirstName = entity.ContactFirstName,
                    ContactLastName = entity.ContactLastName,
                    ContactEmail = entity.ContactEmail,
                    ContactPhone = entity.ContactPhone,
                    Position = entity.Position,
                    CompanyAddress = entity.CompanyAddress,
                    Country = entity.Country,
                    City = entity.City,
                    Wage = entity.Wage,
                    JobOfferStatus = entity.JobOfferStatus,
                    HousingProvided = entity.HousingProvided,
                });
            }
            return Ok(views);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> Create(CreateEmployerView view)
        {
            var model = view.ConvertToEntity();
            var id = await _repository.CreateAsync(model);

            return new ObjectResult(id) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(UpdateEmployerView view, Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            var model = view.ConvertToEntity(entity);
            await _repository.UpdateAsync(model, id);

            return Ok(view);
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
