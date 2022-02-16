﻿using IRIS.BCK.Application.Responses;
using IRIS.BCK.Core.Application.DTO.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter
{
    public class CreateCollectionCenterCommandResponse : BaseResponse
    {
        public CreateCollectionCenterCommandResponse() : base()
        {
        }

        public CollectionCenterDto CollectionCenterdto { get; set; }
    }
}