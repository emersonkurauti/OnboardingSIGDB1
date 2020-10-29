using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGravarFuncionarioService _gravarFuncionarioService;

        public FuncionarioController(IUnitOfWork unitOfWork, IMapper mapper, IGravarFuncionarioService gravarFuncionarioService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gravarFuncionarioService = gravarFuncionarioService;
        }

        /// <summary>
        /// GET api/funcionario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<FuncionarioDTO>> Get()
        {
            var funcionarios = _unitOfWork.FuncionarioRepository.GetAll();
            var funcionariosDto = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
            return funcionariosDto;
        }

        /// <summary>
        /// GET api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var funcionario = _unitOfWork.FuncionarioRepository.Get(c => c.Id == id);
            if (funcionario == null)
                return BadRequest("Funcionário não encontrado.");

            var funcionarioDto = _mapper.Map<FuncionarioDTO>(funcionario);

            return Ok(funcionarioDto);
        }

        /// <summary>
        /// POST api/funcionario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDTO dto)
        {
            var inseriu = _gravarFuncionarioService.Adicionar(dto);

            if (!inseriu)
                return BadRequest(_gravarFuncionarioService.notificationContext.Notifications);

            dto.Id = _gravarFuncionarioService.Id;
            return Created($"/api/funcionario/{dto.Id}", dto);
        }


        /// <summary>
        /// PUT api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FuncionarioDTO dto)
        {
            if (!_gravarFuncionarioService.Alterar(id, dto))
                return BadRequest(_gravarFuncionarioService.notificationContext.Notifications);

            return Created($"/api/funcionario/{id}", dto);
        }
    }
}
