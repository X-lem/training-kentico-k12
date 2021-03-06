﻿using CMS.DocumentEngine;
using System;

namespace Business.Dto.Schools
{
    public class SchoolDto
    {
        public int NodeId { get; set; }
        public Guid NodeGuid { get; set; }
        public string NodeAlias { get; set; }
        public string SchoolName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public DocumentAttachment Photo { get; set; }
        public string Bio { get; set; }

        public string GeneralAddress => $"{City}, {Country}";
        public string FullAddress => $"{Street} {City}, {State} {Country}, {ZipCode}";
    }
}
