using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia_11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_11.Service
{
    public interface IDbService
    {
        public List<Doctor> GetDoctors();
        public bool AddDoctor(Doctor doctor);
        public bool ModifyDoctor(Doctor modDoctor);
        public bool DeleteDoctor( int id);

    }
}