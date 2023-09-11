using CreateAppleIdServer.DTOs;
using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreateAppleIdServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VMThreadController : ControllerBase
    {
        private readonly IVMThreadService _vmThreadService;
        private readonly StoreDataModel _storeData;
        public VMThreadController(IVMThreadService vMThreadService, StoreDataModel storeData)
        {
            _vmThreadService = vMThreadService;
            _storeData = storeData;
        }

        [HttpPost("Run")]
        public IActionResult Run([FromBody] VMThreadRunDto data)
        {
            return Ok();
        }

    }
}
