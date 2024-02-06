using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Tasks
{
    public class TaskView
    {
        public Guid Id { get; set; }
        public Guid ListId { get; set; }
        public string Name { get; set; } = null!;
    }
}
