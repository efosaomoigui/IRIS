using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Domain.Entities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Mappings
{

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Shipment, ShipmentListViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<CreateShipmentCommand, Shipment>();
            CreateMap<Shipment, CreateShipmentCommand>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<RoleDto, AppRole>();
            CreateMap<AppRole, RoleDto>();

            CreateMap<ClaimRoleDto, AppRoleClaim>();
            CreateMap<AppRoleClaim, ClaimRoleDto>();

            CreateMap<RoleListViewModel, AppRole>();
            CreateMap<AppRole, RoleListViewModel>();

            CreateMap<UserRoleDto, AppUserRole>();
            CreateMap<AppUserRole, UserRoleDto>();
        }
    }
}
