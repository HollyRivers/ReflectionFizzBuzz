using System.Reflection;

namespace ReflectionFizzBuzz.Entities;

public sealed record DivisibleReplacementRule : IReplacementRule
{
	public int Divisor { get; init; }
	public string ReplacementWord { get; init; } = string.Empty;
	public MethodInfo? MethodInfo { get; init; }
}