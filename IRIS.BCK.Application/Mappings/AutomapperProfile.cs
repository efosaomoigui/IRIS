using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Domain.Entities;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
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

            CreateMap<WalletNumberDto, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberDto>();

            CreateMap<WalletNumberViewModel, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberViewModel>();

            CreateMap<WalletTransactionDto, WalletTransaction>();
            CreateMap<WalletTransaction, WalletTransactionDto>();

            CreateMap<Route, RouteViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<CreateFleetCommand, Fleet>();
            CreateMap<Fleet, CreateFleetCommand>();

            CreateMap<Fleet, FleetListViewModel>();
            CreateMap<User, UserListViewModel>();

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

            CreateMap<RouteDto, Route>();
            CreateMap<Route, RouteDto>();

            CreateMap<FleetDto, Fleet>();
            CreateMap<Fleet, FleetDto>();
        }
    }
}