using Domain.DTO;
using Domain.Views.Tasks;
namespace Domain.Extensions
{
    public static class TaskExtensions
    {
        public static TaskView ConvertToView (this DTO.Task entity)
        {
            return new TaskView()
            {
                Id = entity.Id,
                ListId = entity.ListId,
            };
        }
        public static DTO.Task ConvertToEntity (this CreateTaskView view)
        {
            return new DTO.Task()
            {
                ListId = view.ListId,
                Title = view.Title,
            };
        }
        public static DTO.Task ConvertToEntity(this UpdateTaskView view)
        {
            return new DTO.Task()
            {
                ListId = view.ListId,
                Id = view.Id,
            };
        }
    }
}

