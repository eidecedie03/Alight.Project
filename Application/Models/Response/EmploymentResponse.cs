using Application.Dtos.Common;

namespace Application.Models.Response
{
    public class EmploymentResponse : BaseModel
    {
        public string Company { get; set; }
        public uint MonthsOfExperience { get; set; }
        public uint Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
