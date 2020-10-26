using Microsoft.AspNetCore.Mvc;
using OnboardingSIGDB1.Data;

namespace OnboardingSIGDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private IUnitOfWork _unitOfWork { get; }

        public EmpresaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_unitOfWork.EmpresaRepository.GetAll());
        }
    }
}
