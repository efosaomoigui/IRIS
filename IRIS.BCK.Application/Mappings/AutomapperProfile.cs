using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Domain.Entities;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
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

            CreateMap<CreateCollectionCenterCommand, CollectionCenter>();
            CreateMap<CollectionCenter, CreateCollectionCenterCommand>();

            CreateMap<CreateGroupWayBillCommand, GroupWayBill>();
            CreateMap<GroupWayBill, CreateGroupWayBillCommand>();

            CreateMap<CreateTripCommand, Trips>();
            CreateMap<Trips, CreateTripCommand>();

            CreateMap<CreatePriceCommand, PriceEnt>();
            CreateMap<Trips, CreateTripCommand>();

            CreateMap<CreateWalletNumberCommand, WalletNumber>();
            CreateMap<WalletNumber, CreateWalletNumberCommand>();

            CreateMap<GetShipmentListQuery, ShipmentListViewModel>();
            CreateMap<ShipmentListViewModel, GetShipmentListQuery>();

            CreateMap<GetPriceQuery, PriceListViewModel>();
            CreateMap<PriceListViewModel, GetPriceQuery>();

            CreateMap<GetRouteQuery, RouteViewModel>();
            CreateMap<RouteViewModel, GetRouteQuery>();

            CreateMap<WalletNumberDto, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberDto>();

            CreateMap<WalletNumberViewModel, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberViewModel>();

            CreateMap<WalletTransactionDto, WalletTransaction>();
            CreateMap<WalletTransaction, WalletTransactionDto>();

            CreateMap<WalletTransaction, WalletNumberViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<Route, RouteViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<Route, RouteViewModel>();
            CreateMap<RouteViewModel, Route>();

            CreateMap<CreateFleetCommand, Fleet>();
            CreateMap<Fleet, CreateFleetCommand>();

            CreateMap<CreatePriceCommand, PriceEnt>();
            CreateMap<PriceEnt, CreatePriceCommand>();

            CreateMap<PriceEnt, PriceListViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<Fleet, FleetListViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<CollectionCenter, FleetListViewModel>();
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

            CreateMap<PriceDto, PriceEnt>();
            CreateMap<PriceEnt, PriceDto>();

            CreateMap<CollectionCenterDto, CollectionCenter>();
            CreateMap<CollectionCenter, CollectionCenterDto>();

            CreateMap<GroupWayBillDto, GroupWayBill>();
            CreateMap<GroupWayBill, GroupWayBillDto>();

            CreateMap<ManifestDto, Manifest>();
            CreateMap<Manifest, ManifestDto>();

            CreateMap<TripDto, Trips>();
            CreateMap<Trips, TripDto>();

            CreateMap<GroupWayBill, GroupWayBillListViewModel>();
            CreateMap<GroupWayBillListViewModel, GroupWayBill>();

            CreateMap<Shipment, ShipmentListViewModel>();
            CreateMap<ShipmentListViewModel, Shipment>();
        }
    }
}