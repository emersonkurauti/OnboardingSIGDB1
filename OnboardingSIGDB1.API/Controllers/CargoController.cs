using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entitys;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;

namespace OnboardingSIGDB1.API.Controllers
{
    /// <summary>
    /// Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly IRepository<Cargo> _cargoRepository;
        private readonly IMapper _mapper;
        private readonly IGravarCargoService _gravarCargoService;
        private readonly IRemoverCargoService _removerService;

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="cargoRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="gravarCargoService"></param>
        /// <param name="removerService"></param>
        public CargoController(IRepository<Cargo> cargoRepository, IMapper mapper, IGravarCargoService gravarCargoService,
            IRemoverCargoService removerService)
        {
            _cargoRepository = cargoRepository;
            _mapper = mapper;
            _gravarCargoService = gravarCargoService;
            _removerService = removerService;
        }

        /// <summary>
        /// GET api/cargo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CargoDTO> Get()
        {
            var cargos = _cargoRepository.GetAll();
            var cargosDto = _mapper.Map<IEnumerable<CargoDTO>>(cargos);
            return cargosDto;
        }

        /// <summary>
        /// GET api/cargo/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cargo = _cargoRepository.Get(c => c.Id == id);
            if (cargo == null)
                return BadRequest("Cargo não encontrado.");

            var cargoDto = _mapper.Map<CargoDTO>(cargo);

            return Ok(cargoDto);
        }

        /// <summary>
        /// POST api/cargo
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(CargoDTO dto)
        {            
            if (!_gravarCargoService.Adicionar(ref dto))
                return BadRequest(_gravarCargoService.notificationContext.Notifications);

            return Created($"/api/cargo/{dto.Id}", dto);
        }

        /// <summary>
        /// PUT api/cargo/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, CargoDTO dto)
        {
            if (!_gravarCargoService.Alterar(id, dto))
                return BadRequest(_gravarCargoService.notificationContext.Notifications);

            return Created($"/api/cargo/{id}", dto);
        }

        /// <summary>
        /// DELETE api/cargo/1
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
