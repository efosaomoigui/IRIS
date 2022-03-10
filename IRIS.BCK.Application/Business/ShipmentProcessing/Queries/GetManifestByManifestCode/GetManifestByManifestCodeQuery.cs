using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode
{
    public class GetManifestByManifestCodeQuery : IRequest<ManifestViewModel>
    {
        public string ManifestCode { get; set; }

        public GetManifestByManifestCodeQuery(string manifestcode)
        {
            string ManifestStr = new string(manifestcode);
            ManifestCode = ManifestStr;
        }
    }
}