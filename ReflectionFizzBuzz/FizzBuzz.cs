using System.Reflection;
using System.Text;

namespace ReflectionFizzBuzz; 

public sealed class FizzBuzz {
	private readonly Dictionary<int, MethodInfo> _replacements = new();

	public void PrintBetween(int minimum, int maximum) {
		for (var i = minimum; i <= maximum; i++) {
			Print(i);
		}
	}
	
	public void Print(int number) {
		var output = Generate(number);
		Console.WriteLine(output);
	}

	private string Generate(int number) {
		var output = new StringBuilder();
		foreach (var replacement in _replacements) {
			output.Append(InvokeMethod(number, replacement.Key, replacement.Value));
		}
		var result = output.ToString();
		return result == string.Empty ? number.ToString() : result;
	}

	private string InvokeMethod(int number, int divisor, MethodInfo method) {
		return (string)method.Invoke(this, new object[] { number, divisor });
	}

	public void AddStandardReplacementRules() {
		AddDivisorReplacementRule(3, "Fizz");
		AddDivisorReplacementRule(5, "Buzz");
	}

	public void AddDivisorReplacementRule(int divisor, string replacementWord) {
		var method = GetType().GetMethod(replacementWord, BindingFlags.NonPublic | BindingFlags.Instance);
		_replacements.Add(divisor, method);
	}

	private string Fizz(int number, int divisor) {
		return number % divisor == 0 ? "Fizz" : string.Empty;
	}

	private string Buzz(int number, int divisor) {
		return number % divisor == 0 ? "Buzz" : string.Empty;
	}
}