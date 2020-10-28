using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGravarEmpresaService _gravarEmpresaService;
        private readonly IRemoverEmpresaService _removerEmpresaService;

        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper, IGravarEmpresaService gravarEmpresaService,
            IRemoverEmpresaService removerEmpresaService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _gravarEmpresaService = gravarEmpresaService;
            _removerEmpresaService = removerEmpresaService;
        }

        /// <summary>
        /// GET api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EmpresaDTO>> Get()
        {
            var empresas = _unitOfWork.EmpresaRepository.GetAll();
            var empresasDto = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            return empresasDto;
        }

        /// <summary>
        /// GET api/empresa/4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var empresa = _unitOfWork.EmpresaRepository.Get(e => e.Id == id);

            if (empresa == null)
                return NotFound("Empresa não encontrada.");

            var empresaDto = _mapper.Map<EmpresaDTO>(empresa);
            return Ok(empresaDto);
        }

        /// <summary>
        /// POST api/empresa
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaDTO dto)
        {
            var inseriu = _gravarEmpresaService.Adicionar(dto);

            if (!inseriu)
                return BadRequest(_gravarEmpresaService.notificationContext.Notifications);

            dto.Id = _gravarEmpresaService.Id;
            return Created($"/api/empresa/{dto.Id}", dto);
        }

        /// <summary>
        /// PUT api/empresa/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmpresaDTO dto)
        {
            return Ok();
        }

        /// <summary>
        /// DELETE api/empresa/4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletou = _removerEmpresaService.Remover(id);

            if (!deletou)
                return BadRequest(_removerEmpresaService.notificationContext.Notifications);

            return NoContent();
        }
    }
}
