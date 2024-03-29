﻿using Domain.Common;


namespace Domain.Entities
{
    public class Employment : BaseEntity
    {
        public int UserId { get; set; }
        public string Company { get; set; }
        public uint MonthsOfExperience { get; set; }
        public uint Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
