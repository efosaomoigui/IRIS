using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRIS.BCK.Core.Application.Shared
{
    public static class StaticMessages
    {
        public static string UserExist { get; } = "Unable to create user, User already exist!";
        public static string RoleExist { get; } = "Unable to create role, Role already exist!";
        public static string PriceExist { get; } = "Unable to create price detail, Price item already exist!";
        public static string RoleClaimExist { get; } = "Unable to create  claim for role, claim already exist!";
    }
}
