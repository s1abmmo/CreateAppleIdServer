using CreateAppleIdServer.DTOs;
using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace CreateAppleIdServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IRegistrationInfomationService _registrationInfomationService;
        private readonly StoreDataModel _storeDataModel;
        private readonly IPhoneService _phonesService;
        private readonly IFileService _fileService;
        public DataController(IRegistrationInfomationService registrationInfomationService,
            StoreDataModel storeDataModel,
            IPhoneService phonesService,
            IFileService fileService)
        {
            _registrationInfomationService = registrationInfomationService;
            _storeDataModel = storeDataModel;
            _phonesService = phonesService;
            _fileService = fileService;
        }

        [HttpPost("GetRegistrationInfomation")]
        public IActionResult GetRegistrationInfomation([FromBody] GetRegistrationInfomationDto body)
        {
            Console.WriteLine($"get info from {body.VMName}");
            //_phonesService.Update();
            var i = _storeDataModel.registrationInfomations.FindIndex(e => e.VMName == body.VMName);
            if (i != -1)
            {
                _fileService.InsertCsv(_storeDataModel.registrationInfomations[i]);
                _storeDataModel.registrationInfomations.Remove(_storeDataModel.registrationInfomations[i]);
            }

            try
            {
                var rS = _registrationInfomationService.Create(body.VMName);
                if (rS != null)
                {
                    _storeDataModel.registrationInfomations.Add(rS);
                    return Ok(rS);
                }
                else
                {
                    return BadRequest("No phones");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SendResult")]
        public IActionResult SendResult([FromBody] SendResultDto body)
        {
            Console.WriteLine($"send result from {body.VMName} : {((int)body.FinishStep)}");
            try
            {
                _registrationInfomationService.UpdateFinishStep(_storeDataModel, body.VMName, body.FinishStep);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
