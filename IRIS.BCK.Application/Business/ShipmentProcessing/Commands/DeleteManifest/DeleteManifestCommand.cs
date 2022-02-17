using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.DeleteManifest
{
    public class DeleteManifestCommand : IRequest<DeleteManifestCommandResponse>
    {
        public Guid Id { get; set; }
    }
}