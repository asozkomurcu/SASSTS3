﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS.Application.Models.RequestModels.WholesalersRM
{
    public class UpdateWholesalerVM
    {
        public int Id { get; set; }
        public string WholesalerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}