using AutoMapper;
using IRIS.BCK.Core.Application.Business.Accounts.AccountEntities;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.CreateUser;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetClaimForRole;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetRoles;
using IRIS.BCK.Core.Application.Business.Accounts.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Fleets.Queries;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistory;
using IRIS.BCK.Core.Application.Business.Monitoring.Queries.GetTrackHistoryById;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment.GetPaymentById;
using IRIS.BCK.Core.Application.Business.Price.Commands.CreatePrice;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPrice;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.CreateServiceCenter;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.CreateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Queries.GetShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.CreateTrips;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetTrips;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.CreateShipment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetCollectionCenter;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleets;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetRoutes;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentList;
using IRIS.BCK.Core.Application.Business.Wallet.Commands.CreateWalletNumber;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletById;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletByWalletNumberQuery;
using IRIS.BCK.Core.Application.DTO.Account;
using IRIS.BCK.Core.Application.DTO.Fleets;
using IRIS.BCK.Core.Application.DTO.GroupWayBillManifestMap;
using IRIS.BCK.Core.Application.DTO.Monitoring;
using IRIS.BCK.Core.Application.DTO.Payments;
using IRIS.BCK.Core.Application.DTO.Price;
using IRIS.BCK.Core.Application.DTO.Routes;
using IRIS.BCK.Core.Application.DTO.ServiceCentre;
using IRIS.BCK.Core.Application.DTO.ShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.DTO.ShipmentProcessing;
using IRIS.BCK.Core.Application.DTO.Shipments;
using IRIS.BCK.Core.Application.DTO.Wallet;
using IRIS.BCK.Core.Domain.Entities;
using IRIS.BCK.Core.Domain.Entities.FleetEntities;
using IRIS.BCK.Core.Domain.Entities.GroupWayBillManifestMapEntities;
using IRIS.BCK.Core.Domain.Entities.Monitoring;
using IRIS.BCK.Core.Domain.Entities.PriceEntities;
using IRIS.BCK.Core.Domain.Entities.RouteEntities;
using IRIS.BCK.Core.Domain.Entities.ServiceCenterEntities;
using IRIS.BCK.Core.Domain.Entities.ShimentEntities;
using IRIS.BCK.Core.Domain.Entities.PaymentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentGroupWayBillMapEntities;
using IRIS.BCK.Core.Domain.Entities.ShipmentProcessing;
using IRIS.BCK.Core.Domain.Entities.WalletEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPaymentByInvoiceCode;
using IRIS.BCK.Core.Application.Business.Payments.Queries.GetPayment;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentById;
using IRIS.BCK.Application.DTO;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetShipmentByWayBillNumber;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateGroupWayBill;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifest;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Commands.UpdateManifest;
using IRIS.BCK.Core.Application.Business.Shipments.Queries.GetFleetById;
using IRIS.BCK.Core.Application.Business.Shipments.Commands.UpdateFleet;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByManifestCode;
using IRIS.BCK.Core.Application.Business.ShipmentProcessing.Queries.GetManifestByGroupWayBill;
using IRIS.BCK.Core.Application.Business.Price.Queries.GetPriceById;
using IRIS.BCK.Core.Application.Business.Monitoring.Commands.CreateTrackHistory;
using IRIS.BCK.Core.Application.Business.Accounts.Commands.UpdateUsers;
using IRIS.BCK.Core.Application.Business.GroupWayBillManifestMaps.Commands.UpdateGroupWayBillManifestMap;
using IRIS.BCK.Core.Application.Business.ShipmentGroupWayBillMaps.Commands.UpdateShipmentGroupWayBillMap;
using IRIS.BCK.Core.Application.Business.Monitoring.Commands.UpdateTrackHistory;
using IRIS.BCK.Core.Application.Business.Payments.Commands.UpdatePayment;
using IRIS.BCK.Core.Application.Business.Price.Commands.UpdatePrice;
using IRIS.BCK.Core.Application.Business.ServiceCentre.Commands.UpdateServiceCenter;
using IRIS.BCK.Core.Application.Business.Wallet.Queries.GetWalletTransactionByWalletNumberQuery;

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

            CreateMap<CreateShipmentGroupWayBillMapCommand, ShipmentGroupWayBillMap>();
            CreateMap<ShipmentGroupWayBillMap, CreateShipmentGroupWayBillMapCommand>();

            CreateMap<CreateTripCommand, Trips>();
            CreateMap<Trips, CreateTripCommand>();

            CreateMap<CreateTrackHistoryCommand, TrackHistory>();
            CreateMap<TrackHistory, CreateTrackHistoryCommand>();

            CreateMap<CreateServiceCenterCommand, ServiceCenter>();
            CreateMap<ServiceCenter, CreateServiceCenterCommand>();

            CreateMap<CreateFleetCommand, Fleet>();
            CreateMap<Fleet, CreateFleetCommand>();

            CreateMap<UpdateGroupWayBillCommand, GroupWayBill>();
            CreateMap<GroupWayBill, UpdateGroupWayBillCommand>();

            CreateMap<UpdateFleetCommand, Fleet>();
            CreateMap<Fleet, UpdateFleetCommand>();

            CreateMap<UpdatePriceCommand, PriceEnt>();
            CreateMap<PriceEnt, UpdatePriceCommand>();

            CreateMap<UpdateServiceCenterCommand, ServiceCenter>();
            CreateMap<ServiceCenter, UpdateServiceCenterCommand>();

            CreateMap<UpdateTrackHistoryCommand, TrackHistory>();
            CreateMap<TrackHistory, UpdateTrackHistoryCommand>();

            CreateMap<UpdateGroupWayBillManifestMapComand, GroupWayBillManifestMap>();
            CreateMap<GroupWayBillManifestMap, UpdateGroupWayBillManifestMapComand>();

            CreateMap<UpdateShipmentGroupWayBillMapCommand, ShipmentGroupWayBillMap>();
            CreateMap<ShipmentGroupWayBillMap, UpdateShipmentGroupWayBillMapCommand>();

            CreateMap<UpdateManifestCommand, Manifest>();
            CreateMap<Manifest, UpdateManifestCommand>();

            CreateMap<UpdatePaymentCommand, Payment>();
            CreateMap<Payment, UpdatePaymentCommand>();

            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UpdateUserCommand>();

            CreateMap<CreatePriceCommand, PriceEnt>();
            CreateMap<PriceEnt, CreateTripCommand>();

            CreateMap<CreateWalletNumberCommand, WalletNumber>();
            CreateMap<WalletNumber, CreateWalletNumberCommand>();

            CreateMap<GetShipmentListQuery, ShipmentListViewModel>();
            CreateMap<ShipmentListViewModel, GetShipmentListQuery>();

            CreateMap<GetPriceQuery, PriceListViewModel>();
            CreateMap<PriceListViewModel, GetPriceQuery>();

            CreateMap<GetManifestQuery, ManifestListViewModel>();
            CreateMap<ManifestListViewModel, GetManifestQuery>();

            CreateMap<GetRouteQuery, RouteViewModel>();
            CreateMap<RouteViewModel, GetRouteQuery>();

            CreateMap<GetTripQuery, TripListViewModel>();
            CreateMap<TripListViewModel, GetTripQuery>();

            CreateMap<GetTrackHistoryQuery, TrackHistoryListViewModel>();
            CreateMap<TrackHistoryListViewModel, GetTrackHistoryQuery>();

            CreateMap<GetWalletByIdQuery, WalletViewModel>();
            CreateMap<WalletViewModel, GetWalletByIdQuery>();

            CreateMap<GetShipmentByIdQuery, ShipmentViewModel>();
            CreateMap<ShipmentViewModel, GetShipmentByIdQuery>();

            CreateMap<GetManifestByManifestCodeQuery, ManifestViewModel>();
            CreateMap<ManifestViewModel, GetManifestByManifestCodeQuery>();

            CreateMap<GetManifestByGroupWayBillQuery, ManifestViewModel>();
            CreateMap<ManifestViewModel, GetManifestByGroupWayBillQuery>();

            CreateMap<GetShipmentByWayBillNumberQuery, ShipmentViewModel>();
            CreateMap<ShipmentViewModel, GetShipmentByWayBillNumberQuery>();

            CreateMap<GetPaymentByIdQuery, PaymentViewModel>();
            CreateMap<PaymentViewModel, GetPaymentByIdQuery>();

            CreateMap<GetFleetByIdQuery, FleetViewModel>();
            CreateMap<FleetViewModel, GetFleetByIdQuery>();

            CreateMap<GetPaymentByInvoiceCodeQuery, PaymentViewModel>();
            CreateMap<PaymentViewModel, GetPaymentByInvoiceCodeQuery>();

            CreateMap<WalletNumberDto, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberDto>();

            CreateMap<PaymentDto, Payment>();
            CreateMap<Payment, PaymentDto>();

            CreateMap<TrackHistoryDto, TrackHistory>();
            CreateMap<TrackHistory, TrackHistoryDto>();

            CreateMap<WalletNumberViewModel, WalletNumber>();
            CreateMap<WalletNumber, WalletNumberViewModel>();

            CreateMap<WalletTransactionDto, WalletTransaction>();
            CreateMap<WalletTransaction, WalletTransactionDto>();

            CreateMap<WalletTransaction, WalletNumberViewModel>();
            CreateMap<User, UserListViewModel>();

            //CreateMap<Route, RouteViewModel>();
            //CreateMap<User, UserListViewModel>();

            CreateMap<Route, RouteViewModel>();
            CreateMap<RouteViewModel, Route>();

            CreateMap<PriceEnt, PriceListViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<Fleet, FleetListViewModel>();
            CreateMap<User, UserListViewModel>();

            CreateMap<CollectionCenter, CollectionCenterListViewModel>();
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

            CreateMap<ShipmentDto, Shipment>();
            CreateMap<Shipment, ShipmentDto>();

            CreateMap<ServiceCenterDto, ServiceCenter>();
            CreateMap<ServiceCenter, ServiceCenterDto>();

            CreateMap<ShipmentGroupWayBillMapDto, ShipmentGroupWayBillMap>();
            CreateMap<ShipmentGroupWayBillMap, ShipmentGroupWayBillMapDto>();

            CreateMap<GroupWayBillManifestMapDto, GroupWayBillManifestMap>();
            CreateMap<GroupWayBillManifestMap, GroupWayBillManifestMapDto>();

            CreateMap<PriceEnt, PriceListViewModel>();
            CreateMap<PriceListViewModel, PriceEnt>();

            CreateMap<PriceEnt, PriceViewModel>();
            CreateMap<PriceViewModel, PriceEnt>();

            CreateMap<Trips, TripListViewModel>();
            CreateMap<TripListViewModel, Trips>();

            CreateMap<GroupWayBill, GroupWayBillListViewModel>();
            CreateMap<GroupWayBillListViewModel, GroupWayBill>();

            CreateMap<TrackHistory, TrackHistoryListViewModel>();
            CreateMap<TrackHistoryListViewModel, TrackHistory>();

            CreateMap<Payment, PaymentListViewModel>();
            CreateMap<PaymentListViewModel, Payment>();

            CreateMap<Shipment, ShipmentListViewModel>();
            CreateMap<ShipmentListViewModel, Shipment>();

            CreateMap<Shipment, ShipmentViewModel>();
            CreateMap<ShipmentViewModel, Shipment>();

            CreateMap<WalletNumber, WalletViewModel>();
            CreateMap<WalletViewModel, WalletNumber>();

            CreateMap<Manifest, ManifestListViewModel>();
            CreateMap<ManifestListViewModel, Manifest>();

            CreateMap<Manifest, ManifestViewModel>();
            CreateMap<ManifestViewModel, Manifest>();

            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PaymentViewModel, Payment>();

            CreateMap<Fleet, FleetViewModel>();
            CreateMap<FleetViewModel, Fleet>();

            CreateMap<TrackHistory, TrackHistoryViewModel>();
            CreateMap<TrackHistoryViewModel, TrackHistory>();

            CreateMap<ShipmentGroupWayBillMap, ShipmentGroupWayBillMapListViewModel>();
            CreateMap<ShipmentGroupWayBillMapListViewModel, ShipmentGroupWayBillMap>();

            CreateMap<AppRoleClaim, ListClaimViewModel>();
            CreateMap<ListClaimViewModel, AppRoleClaim>();

            CreateMap<RoleByIdViewModel, AppRole>();
            CreateMap<AppRole, RoleByIdViewModel>();

            CreateMap<ClaimViewModel, AppRole>();
            CreateMap<AppRole, ClaimViewModel>();

            CreateMap<WalletTransaction, WalletTransactionViewModel>();
            CreateMap<WalletTransactionViewModel, WalletTransaction>();
        }
    }
}