using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface IStoreDataService
    {
        public List<VMThread> GetVMIsChanged(StoreDataModel storeData);
    }
}
