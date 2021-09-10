﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDapper.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        //[Write(false)]
        public List<Employee> Employees { get; set; }
    }
}
