using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cwiczenia_11.Models;
using Cwiczenia_11.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService service;

        public DoctorController(IDbService _service)
        {
            service = _service;
        }


        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<Doctor> list = service.GetDoctors();

            return Ok(list);
        }

        [HttpPut]
        public IActionResult AddDoctor(Doctor doctor)
        {
            bool czyDod = service.AddDoctor(doctor);
            if (czyDod) return Ok();
            return BadRequest();
        }

        [HttpPut("modify")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            bool czyZmod = service.ModifyDoctor(doctor);
            if (czyZmod) return Ok(doctor);

            return NotFound("brak lekarza o podanym Id");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            bool czyUsuniety = service.DeleteDoctor(id);

            if (czyUsuniety)
                return Ok("Doktor dodany");
            return BadRequest("Nie ma doktora o podanym numerze ID");
        }
    }
}