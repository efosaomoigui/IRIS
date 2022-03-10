using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById
{
    public class GetPriceByIdQuery : IRequest<PriceViewModel>
    {
        public Guid Id { get; set; }

        public GetPriceByIdQuery(string priceid)
        {
            Guid PriceGuid = new Guid(priceid);
            Id = PriceGuid;
        }
    }
}