using CreateAppleIdServer.Enums;
using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface IRegistrationInfomationService
    {
        public RegistrationInfomation? Create(string vmName);
        public void UpdateFinishStep(StoreDataModel storeData, string vMName, FinishStepEnum finishStep);
    }
}
