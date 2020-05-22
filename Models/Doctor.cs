﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_11.Models
{
    public class Doctor
    {
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public Doctor()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

      

    }
}