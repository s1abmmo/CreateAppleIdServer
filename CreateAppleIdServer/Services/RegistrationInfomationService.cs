using CreateAppleIdServer.Enums;
using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class RegistrationInfomationService
    {
        private readonly StoreDataModel _storeDataModel;
        private readonly IConfiguration _configuration;
        public readonly string[] FirstNames = { "Tran", "Le" };
        public readonly string[] LastNames = { "Trang", "Manh" };
        public readonly string[] Streets = { "50 jf ut", "48 fh" };
        public readonly string[] Cities = { "hn", "hcm" };
        public readonly string[] keywordsSearch = { "vpn" };
        //private readonly char[] specialChars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
        private readonly char[] alphaChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private readonly string[] nameMonths = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };
        public RegistrationInfomationService(IConfiguration configuration, StoreDataModel storeDataModel)
        {
            _configuration = configuration;
            _storeDataModel = storeDataModel;
        }
        public RegistrationInfomation? Create(string vmName)
        {
            Random rd = new Random();
            var fistName = FirstNames[rd.Next(0, FirstNames.Length)];
            var lastName = LastNames[rd.Next(0, LastNames.Length)];
            var nameAppleId = (fistName + lastName).ToLower();
            var maxLengthName = rd.Next(16, 18);
            for (int i = nameAppleId.Length + 5; i < maxLengthName; i++)
            {
                nameAppleId += alphaChars[rd.Next(0, alphaChars.Length)];
            }
            nameAppleId += rd.Next(10000, 99999).ToString();
            var password = _configuration["CommonPassword"]; ;
            var phone = _storeDataModel.GetPhone();
            if (phone == null)
            {
                return null;
            }

            var macPassword = "111111";
            var street = Streets[rd.Next(0, Streets.Length)];
            var city = Cities[rd.Next(0, Cities.Length)];
            var postCode = "100000";
            var areaCode = "84";
            var keywordSearch = keywordsSearch[rd.Next(0, keywordsSearch.Length)];
            var dayOfBirth = rd.Next(1, 20).ToString("00");
            var monthOfBirth = nameMonths[rd.Next(0, nameMonths.Length)];
            var yearOfBirth = rd.Next(1990, 2001).ToString("0000");

            return new RegistrationInfomation()
            {
                VMName = vmName,
                FirstName = fistName,
                LastName = lastName,
                NameAppleId = nameAppleId,
                Password = password!,
                Phone = phone,
                MacPassword = macPassword,
                Street = street,
                City = city,
                PostCode = postCode,
                AreaCode = areaCode,
                KeywordSearch = keywordSearch,
                DayOfBirth = dayOfBirth,
                MonthOfBirth = monthOfBirth,
                YearOfBirth = yearOfBirth
            };
        }

        public void UpdateFinishStep(StoreDataModel storeData, string vMName, FinishStepEnum finishStep)
        {
            var i = storeData.registrationInfomations.FindIndex(item => item.VMName == vMName);
            if (i == -1)
            {
                throw new Exception("Not found VMName");
            }
            else
            {
                storeData.registrationInfomations[i].FinishStep = finishStep;
            }
        }

    }
}
