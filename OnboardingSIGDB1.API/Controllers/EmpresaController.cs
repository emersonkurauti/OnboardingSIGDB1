using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data.Repositories;
using OnboardingSIGDB1.Data.Repositories.Interfaces;
using OnboardingSIGDB1.Domain.Entitys;
using System.Collections.Generic;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _repo { get; }

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _repo = empresaRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok("Retornou com sucesso!");
        }
    }
}
