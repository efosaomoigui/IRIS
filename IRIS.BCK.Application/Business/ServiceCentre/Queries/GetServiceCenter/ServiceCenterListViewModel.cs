﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ServiceCentre.Queries.GetServiceCenter
{
    public class ServiceCenterListViewModel
    {
        public Guid ServiceCenterId { get; set; }
        public string ServiceCenterName { get; set; }
        public string State { get; set; }
        public string ServiceCenterCountry { get; set; }
    }
}