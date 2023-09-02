using CreateAppleIdServer.Enums;

namespace CreateAppleIdServer.Models
{
    public class SendResultDto
    {
        public string VMName { get; set; } = "";
        public FinishStepEnum FinishStep { get; set; } = FinishStepEnum.CreateInfo;
    }
}
