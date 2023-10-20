using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Stytch.Net.Models;

/// <summary>
///     AND – All the operand values provided must match.
///     OR – The operator will return any matches to at least one of the operand values you supply.
/// </summary>
public enum OperatorEnum
{
    [EnumMember(Value = "OR")] Or,
    [EnumMember(Value = "AND")] And
}

public class Query
{
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("operator")]
    public OperatorEnum Operator { get; set; }

    [JsonProperty("operands")] public IOperandValue[]? Operands { get; set; }
}