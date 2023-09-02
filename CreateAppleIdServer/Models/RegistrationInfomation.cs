using CreateAppleIdServer.Enums;

namespace CreateAppleIdServer.Models
{
    public class RegistrationInfomation
    {
        public string VMName { get; set; } = "";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string NameAppleId { get; set; } = "";
        public string Password { get; set; } = "";
        public string Phone { get; set; } = "";
        public string MacPassword { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string PostCode { get; set; } = "";
        public string AreaCode { get; set; } = "";
        public string KeywordSearch { get; set; } = "";
        public FinishStepEnum FinishStep { get; set; } = FinishStepEnum.CreateInfo;
    }
}
