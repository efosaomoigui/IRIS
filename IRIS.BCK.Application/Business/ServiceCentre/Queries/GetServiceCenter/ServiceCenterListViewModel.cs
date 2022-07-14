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
        public string ServiceCode { get; set; }
        public string ServiceCenterName { get; set; }
        public string State { get; set; }
        public string ServiceCenterCountry { get; set; }
        public string ServiceTag { get; set; }
    }

    public class ServiceCenterJsonListViewModel 
    {
        public Guid ServiceCenterId { get; set; }
        public string Terminals { get; set; } 
        public string Code { get; set; }
        public string Type { get; set; }  
        public string Phone { get; set; }  
        public string Address { get; set; }   
        public string City { get; set; } 
        public string State { get; set; }
        public string Location { get; set; } 
        public string Coordinate { get; set; } 
    }
}