using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class PhonesService
    {
        private StoreDataModel _storeDataModel;
        public PhonesService(StoreDataModel storeDataModel)
        {
            _storeDataModel = storeDataModel;
        }

        public void Update()
        {
            try
            {
                var phones = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phones.txt"));
                foreach (var phone in phones)
                {
                    _storeDataModel.phones.Add(phone);
                }

                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phones.txt"), "");
            }
            catch { }
        }
    }
}
