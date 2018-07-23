using System.Runtime.Serialization;

namespace model
{
    public enum PromotioType
    {
        [EnumMember(Value = "Percentage")]
        PERCENTAGE = 1,
        [EnumMember(Value = "Fixed")]
        FIXED = 2
    }
}