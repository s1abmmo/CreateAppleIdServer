using CreateAppleIdServer.DTOs;
using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreateAppleIdServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly SettingModel _setting;
        public SettingController(ISettingService settingService, SettingModel setting)
        {
            _settingService = settingService;
            _setting = setting;
        }

        [HttpPatch("AddCompressedDirectoryPath")]
        public IActionResult AddCompressedDirectoryPath([FromBody] AddCompressedDirectoryPathDto data)
        {
            try
            {
                _settingService.AddCompressedFilePath(_setting, data.Path);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
