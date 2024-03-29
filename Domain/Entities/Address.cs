﻿using Domain.Common;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int? PostCode { get; set; }
    }
}
