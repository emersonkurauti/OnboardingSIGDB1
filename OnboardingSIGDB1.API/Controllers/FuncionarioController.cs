﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.API.Filtros;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;

namespace OnboardingSIGDB1.API.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGravarFuncionarioService _gravarFuncionarioService;
        private readonly IRemoverFuncionarioService _removerService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="gravarFuncionarioService"></param>
        /// <param name="removerService"></param>
        public FuncionarioController(IUnitOfWork unitOfWork, IMapper mapper, IGravarFuncionarioService gravarFuncionarioService,
            IRemoverFuncionarioService removerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gravarFuncionarioService = gravarFuncionarioService;
            _removerService = removerService;
        }

        /// <summary>
        /// GET api/funcionario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FuncionarioDTO> Get()
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
        /// GET api/funcionario/pesquisar
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("pesquisar")]
        public IEnumerable<FuncionarioDTO> Get([FromQuery] FiltrosFuncionario filtro)
        {
            var funcionarios = _unitOfWork.FuncionarioRepository.GetAll();
            var funcionariosDto = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);

            if (filtro.Nome != null)
            {
                var regex = new Regex(filtro.Nome, RegexOptions.IgnoreCase);
                funcionariosDto = funcionariosDto.Where(f => regex.IsMatch(f.Nome));
            }

            if (filtro.Cpf != null)
                funcionariosDto = funcionariosDto.Where(f => f.Cpf == filtro.Cpf);

            if (filtro.dtInicio != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao >= filtro.dtInicio);

            if (filtro.dfFim != null)
                funcionariosDto = funcionariosDto.Where(f => f.DataContratacao <= filtro.dfFim);

            return funcionariosDto;
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
        public IActionResult Put(int id, FuncionarioAlteracaoDTO dto)
        {
            if (!_gravarFuncionarioService.Alterar(id, dto))
                return BadRequest(_gravarFuncionarioService.notificationContext.Notifications);

            return Created($"/api/funcionario/{id}", dto);
        }

        /// <summary>
        /// DELETE api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removerService.Remover(id))
                return BadRequest(_removerService.notificationContext.Notifications);

            return NoContent();
        }
    }
}
