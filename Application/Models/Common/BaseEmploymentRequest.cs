namespace Application.Dtos.Common
{
    public class BaseEmploymentRequest
    {
        public string Company { get; set; }
        public int MonthsOfExperience { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
