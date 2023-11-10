using System.Reflection;

namespace ReflectionFizzBuzz.Entities; 

public interface IReplacementRule {
	public string ReplacementWord { get; init; }
	public MethodInfo? MethodInfo { get; init; }
}