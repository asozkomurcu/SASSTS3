﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.CompaniesRM
{
    public class UpdateCompanyVM
    {
        public int Id { get; set; }
        public int? CompanyManagerId { get; set; }
        public string? CompanyManagerName { get; set; }
        public string CompanyName { get; set; }
    }
}
