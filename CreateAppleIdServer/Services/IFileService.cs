using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface IFileService
    {
        public void InsertCsv(RegistrationInfomation regInfo);
    }
}
