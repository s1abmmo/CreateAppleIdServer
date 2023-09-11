using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class StoreDataService : IStoreDataService
    {
        public StoreDataService() { }
        public List<VMThread> GetVMIsChanged(StoreDataModel storeData)
        {
            List<VMThread> vmThreads = storeData.vMThreads.FindAll(e => e.IsChanged);
            foreach (var vmThread in storeData.vMThreads)
            {
                vmThread.IsChanged = false;
            }
            return vmThreads;
        }
    }
}
