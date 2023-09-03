using CreateAppleIdServer.Enums;
using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class FileService
    {
        private readonly string pathCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "export.csv");
        public FileService() { }
        public void InsertCsv(RegistrationInfomation regInfo)
        {
            string result = "Error";
            if (regInfo.FinishStep == FinishStepEnum.Register)
            {
                result = "Not complete Review & Download";
            }

            if (regInfo.FinishStep == FinishStepEnum.ReviewDownload)
            {
                result = "Complete";
            }

            string content = $"\"{regInfo.VMName}\",\"{regInfo.CreateAt}\",\"{regInfo.FirstName}\",\"{regInfo.LastName}\",\"{regInfo.Password}\",\"{regInfo.Phone}\",\"{regInfo.MacPassword}\",\"{regInfo.Street}\",\"{regInfo.City}\",\"{regInfo.PostCode}\",\"{regInfo.AreaCode}\",\"{regInfo.KeywordSearch}\",\"{result}\"{Environment.NewLine}";
            File.AppendAllText(pathCsv, content);
            Console.WriteLine($"write csv {regInfo.VMName}");
        }

    }
}
