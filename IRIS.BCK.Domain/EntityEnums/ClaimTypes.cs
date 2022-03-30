namespace  IRIS.BCK.Core.Domain.EntityEnums
{
    public enum ClaimTypes 
    {
        //Admin 
        CreateUser,
        CreatePermission,
        CreateRole,
        AddRoleToUser,
        AddRolePermission,
        ViewUsers,
        ViewRoles,
        ViewPermissions,

        //Wallet
        CreditWallet,
        DebitWallet,
        DeactivateWallet,
        ActivateWallet,
        ViewUserWallet,
        ViewWalletTransactions,

        //Shipment
        CreateShipment,
        ViewShipment,

        //Payment
        ViewPayments,

        //Invoice
        ViewInvoices,

    }
}
