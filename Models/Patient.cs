using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia_11.Models
{
    public class Patient
    {
        public virtual ICollection<Prescription> Prescription { get; set; }
        public Patient()
        {
            Prescription = new HashSet<Prescription>();
        }
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


    }
}
