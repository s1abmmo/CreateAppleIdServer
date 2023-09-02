using Microsoft.AspNetCore.Mvc;

namespace CreateAppleIdServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScriptController : ControllerBase
    {
        public IActionResult DownloadFile()
        {
            // Đường dẫn đến tệp tin cần tải xuống
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "script.zip");

            // Đọc dữ liệu từ tệp tin vào một mảng byte
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Đặt tên tệp tin và loại tệp tin cho phản hồi
            string fileName = "script.zip";
            string contentType = "application/octet-stream";

            // Trả về một FileResult với dữ liệu tệp tin
            return File(fileBytes, contentType, fileName);
        }
    }
}
