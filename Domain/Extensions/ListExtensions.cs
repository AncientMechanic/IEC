using Domain.DTO;
using Domain.Views.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Extensions
{
    public static class ListExtensions
    {
        public static ListView ConvertToView(this List entity)
        {
            return new ListView()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Name = entity.Name,
            };
        }
        public static List ConvertToEntity(this CreateListView view)
        {
            return new List()
            {
                UserId = view.UserId,
                Name = view.Name,
            };
        }
        public static List ConvertToEntity(this UpdateListView view)
        {
            return new List()
            {
                UserId = view.UserId,
                Id = view.Id,
            };
        }
    }
}
