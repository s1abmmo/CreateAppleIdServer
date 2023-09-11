namespace CreateAppleIdServer.Models
{
    public class StoreDataModel
    {
        public List<RegistrationInfomation> registrationInfomations = new List<RegistrationInfomation>();
        //private List<string> phones = new List<string>();
        public List<VMThread> vMThreads = new List<VMThread>();
        public StoreDataModel()
        {

        }

        //public void AddNewPhone(string phone)
        //{
        //    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} them so {phone}");
        //    phones.Add(phone);
        //}

        //public string? GetPhone()
        //{
        //    if (phones.Count < 1)
        //    {
        //        return null;
        //    }
        //    var phone = phones[0];
        //    phones.RemoveAt(0);
        //    Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} lay so {phone} con {phones.Count} so");
        //    return phone;
        //}

    }
}
