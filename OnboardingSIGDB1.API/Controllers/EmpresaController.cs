using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
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

        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// GET api
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var empresas = _unitOfWork.EmpresaRepository.GetAll();
            var empresasDto = _mapper.Map<IEnumerable<EmpresaDTO>>(empresas);

            return Ok(empresasDto);
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
            return Ok();
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
            return Ok();
        }
    }
}
