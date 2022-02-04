using AutoMapper;
using IRIS.BCK.Application.Interfaces.IRepository;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.Interfaces.IFiles.ICsv;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;  

namespace IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles
{
    class GetRoleExportQueryHandler : IRequestHandler<GetRoleExportQuery, RoleExportFileVm>
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvexporter; 
        private readonly ICsvExporterForRoles _csvexporterforroles;


        public GetRoleExportQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper, ICsvExporter csvexporter, ICsvExporterForRoles csvexporterforroles)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _csvexporter = csvexporter;
            _csvexporterforroles = csvexporterforroles;
        }

        public async Task<RoleExportFileVm> Handle(GetRoleExportQuery request, CancellationToken cancellationToken)
        {
            var roleResult = ( _roleManager.Roles.ToList()).OrderBy(x => x.Name);
            var allRoles = _mapper.Map<List<RoleExportDto>>(roleResult);


            var fileData = _csvexporterforroles.ExportFilesToCsv(allRoles);
            var roleexportdto = new RoleExportFileVm()
            {
                ContentType = "Text/csv",
                data = fileData,
                Name = $"{Guid.NewGuid()}.csv"
            };

            return roleexportdto;
        }
    }
}
