using System.ComponentModel;

namespace IRIS.BCK.Core.Domain.EntityEnums
{
    public enum ActionType
    {
        [Description("Start Movement")]
        Start,

        [Description("In Transit")]
        Transit,

        [Description("Stop Movement")]
        Stop,  
    }
}