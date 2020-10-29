using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGravarFuncionarioCargoService _gravarFuncionarioCargoService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="gravarFuncionarioCargoService"></param>
        public FuncionarioCargoController(IUnitOfWork unitOfWork, IMapper mapper, IGravarFuncionarioCargoService gravarFuncionarioCargoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gravarFuncionarioCargoService = gravarFuncionarioCargoService;
        }

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
