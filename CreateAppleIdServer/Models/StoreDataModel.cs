namespace CreateAppleIdServer.Models
{
    public class StoreDataModel
    {
        public List<RegistrationInfomation> registrationInfomations = new List<RegistrationInfomation>();
        private List<string> phones = new List<string>();
        public StoreDataModel()
        {

        }

        public void AddNewPhone(string phone)
        {
            phones.Add(phone);
        }

        public string? GetPhone()
        {
            if (phones.Count < 1)
            {
                return null;
            }
            var phone = phones[0];
            phones.RemoveAt(0);
            return phone;
        }

    }
}
