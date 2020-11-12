using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.API.Filtros;
using OnboardingSIGDB1.Domain.Dto;
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
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        private readonly IGravarFuncionarioService _gravarFuncionarioService;
        private readonly IRemoverFuncionarioService _removerService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="funcionarioRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="gravarFuncionarioService"></param>
        /// <param name="removerService"></param>
        public FuncionarioController(IFuncionarioRepository funcionarioRepository, IMapper mapper, IGravarFuncionarioService gravarFuncionarioService,
            IRemoverFuncionarioService removerService)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
            _gravarFuncionarioService = gravarFuncionarioService;
            _removerService = removerService;
        }

        /// <summary>
        /// GET api/funcionario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<FuncionarioConsultaDTO> Get()
        {
            return _funcionarioRepository.GetAllFuncionarios();
        }

        /// <summary>
        /// GET api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var funcionario = _funcionarioRepository.GetFuncionario(id);
            if (funcionario == null)
                return BadRequest("Funcionário não encontrado.");

            return Ok(funcionario);
        }

        /// <summary>
        /// GET api/funcionario/pesquisar
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("pesquisar")]
        public IEnumerable<FuncionarioConsultaDTO> Get([FromQuery] FiltrosFuncionario filtro)
        {
            var funcionarios = _funcionarioRepository.GetAllFuncionarios();
            var funcionariosDto = _mapper.Map<IEnumerable<FuncionarioConsultaDTO>>(funcionarios);

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
            if (!_gravarFuncionarioService.Adicionar(ref dto))
                return BadRequest(_gravarFuncionarioService.notificationContext.Notifications);

            return Created($"/api/funcionario/{dto.Id}", dto);
        }


        /// <summary>
        /// PUT api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionarioDTO dto)
        {
            if (!_gravarFuncionarioService.Alterar(id, dto))
                return BadRequest(_gravarFuncionarioService.notificationContext.Notifications);

            return Created($"/api/funcionario/{id}", dto);
        }

        /// <summary>
        /// PUT api/funcionario/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult VincularFuncionarioEmpresa(int id, [FromBody] FuncionarioEmpresaDTO dto)
        {
            if (!_gravarFuncionarioService.VincularEmpresa(id, dto))
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
