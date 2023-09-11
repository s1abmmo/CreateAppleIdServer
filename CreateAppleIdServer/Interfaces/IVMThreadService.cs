using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface IVMThreadService
    {
        public void UpdateVMThread(SettingModel setting, StoreDataModel storeData);
    }
}
