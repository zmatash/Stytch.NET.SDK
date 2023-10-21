using System.Runtime.Serialization;

namespace Stytch.Net.Common.Types;

public enum LanguageTag
{
    [EnumMember(Value = "en")] En,
    [EnumMember(Value = "es")] Es,
    [EnumMember(Value = "pt-br")] PtBr
}