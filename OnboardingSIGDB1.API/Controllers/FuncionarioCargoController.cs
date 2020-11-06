using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;

namespace OnboardingSIGDB1.API.Controllers
{
    /// <summary>
    /// Controller de funcionários/cargos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioCargoController : ControllerBase
    {
        private readonly IGravarFuncionarioCargoService _gravarFuncionarioCargoService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="gravarFuncionarioCargoService"></param>
        public FuncionarioCargoController(IGravarFuncionarioCargoService gravarFuncionarioCargoService)
        {
            _gravarFuncionarioCargoService = gravarFuncionarioCargoService;
        }

        /// <summary>
        /// POST api/funcionariocargo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FuncionarioCargoDTO dto)
        {
            var inseriu = _gravarFuncionarioCargoService.Adicionar(dto);

            if (!inseriu)
                return BadRequest(_gravarFuncionarioCargoService.notificationContext.Notifications);

            return Created(string.Empty, dto);
        }
    }
}
