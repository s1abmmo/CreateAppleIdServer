using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class PhonesService:IPhoneService
    {
        private StoreDataModel _storeDataModel;
        public PhonesService(StoreDataModel storeDataModel)
        {
            _storeDataModel = storeDataModel;
        }

        public string? GetAPhone()
        {
            try
            {
                var phones = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phones.txt")).ToList();
                //foreach (var phone in phones)
                //{
                //    _storeDataModel.AddNewPhone(phone);
                //}
                if (phones.Count < 1)
                {
                    return null;
                }
                string phone = phones[0];
                phones.RemoveAt(0);

                File.WriteAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phones.txt"), phones);

                return phone;
            }
            catch
            {
                return null;
            }

        }
    }
}
