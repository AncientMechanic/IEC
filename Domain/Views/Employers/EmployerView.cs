﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Employers
{
    public class EmployerView
    {
        public Guid Id { get; set; }
        public Guid ParticipantId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactFirstName { get; set;} = null!;
        public string ContactLastName { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
