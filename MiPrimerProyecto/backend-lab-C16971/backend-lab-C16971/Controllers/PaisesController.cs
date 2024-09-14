using backend_lab_C16971.Handlers;
using backend_lab_C16971.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_C16971.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisesHandler;
        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }
        [HttpGet]
        public List<PaisesModel> Get()
        {
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }
    }
}
