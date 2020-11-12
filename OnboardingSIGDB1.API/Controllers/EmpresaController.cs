using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.API.Filtros;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OnboardingSIGDB1.API.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IRepository<Empresa> _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IGravarEmpresaService _gravarEmpresaService;
        private readonly IRemoverEmpresaService _removerEmpresaService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="empresaRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="gravarEmpresaService"></param>
        /// <param name="removerEmpresaService"></param>
        public EmpresaController(IRepository<Empresa> empresaRepository, IMapper mapper, IGravarEmpresaService gravarEmpresaService,
            IRemoverEmpresaService removerEmpresaService)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _gravarEmpresaService = gravarEmpresaService;
            _removerEmpresaService = removerEmpresaService;
        }

        /// <summary>
        /// GET api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<EmpresaDTO> Get()
        {
            var empresas = _empresaRepository.GetAll();
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
            var empresa = _empresaRepository.Get(e => e.Id == id);

            if (empresa == null)
                return NotFound("Empresa não encontrada.");

            var empresaDto = _mapper.Map<EmpresaDTO>(empresa);
            return Ok(empresaDto);
        }

        /// <summary>
        /// GET api/empresa/pesquisar
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("pesquisar")]
        public IEnumerable<EmpresaDTO> Get([FromQuery] FiltrosEmpresa filtro)
        {
            var empresas = _empresaRepository.GetAll();
            var empresasDto = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            if (filtro.Nome != null)
            {
                var regex = new Regex(filtro.Nome, RegexOptions.IgnoreCase);
                empresasDto = empresasDto.Where(e => regex.IsMatch(e.Nome));
            }

            if (filtro.Cnpj != null)
                empresasDto = empresasDto.Where(e => e.Cnpj == filtro.Cnpj);

            if (filtro.dtInicio != null)
                empresasDto = empresasDto.Where(e => e.DataFundacao >= filtro.dtInicio);

            if (filtro.dfFim != null)
                empresasDto = empresasDto.Where(e => e.DataFundacao <= filtro.dfFim);

            return empresasDto;
        }

        /// <summary>
        /// POST api/empresa
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EmpresaDTO dto)
        {
            if (!_gravarEmpresaService.Adicionar(ref dto))
                return BadRequest(_gravarEmpresaService.notificationContext.Notifications);

            return Created($"/api/empresa/{dto.Id}", dto);
        }

        /// <summary>
        /// PUT api/empresa/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmpresaDTO dto)
        {
            if (!_gravarEmpresaService.Alterar(id, dto))
                return BadRequest(_gravarEmpresaService.notificationContext.Notifications);

            return Created($"/api/empresa/{id}", dto);
        }

        /// <summary>
        /// DELETE api/empresa/4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_removerEmpresaService.Remover(id))
                return BadRequest(_removerEmpresaService.notificationContext.Notifications);

            return NoContent();
        }
    }
}
