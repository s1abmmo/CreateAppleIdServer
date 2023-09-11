using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface ICsvService
    {
        public void InsertCsv(RegistrationInfomation regInfo);
    }
}
