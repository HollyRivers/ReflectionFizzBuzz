using System.Reflection;
using System.Text;
using ReflectionFizzBuzz.Entities;

namespace ReflectionFizzBuzz; 

public sealed class FizzBuzz
{
	private readonly List<IReplacementRule> _replacements = new();

	public void PrintBetween(int minimum, int maximum)
	{
		if (minimum > maximum)
		{
			throw new ArgumentException("Minimum value cannot be greater than maximum value");
		}
		
		for (var i = minimum; i <= maximum; i++)
		{
			Print(i);
		}
	}
	
	public void Print(int number)
	{
		var output = Generate(number);
		Console.WriteLine(output);
	}

	private string Generate(int number)
	{
		var output = new StringBuilder();
		foreach (var replacement in _replacements)
		{
			output.Append(InvokeMethod(number, replacement));
		}
		var result = output.ToString();
		return result == string.Empty ? number.ToString() : result;
	}

	private string InvokeMethod(int number, IReplacementRule replacement)
	{
		return (string)replacement.MethodInfo.Invoke(this, new object[] { number, replacement });
	}

	public void AddStandardReplacementRules()
	{
		AddDivisorReplacementRule(3, "Fizz");
		AddDivisorReplacementRule(5, "Buzz");
	}

	public void AddDivisorReplacementRule(int divisor, string replacementWord)
	{
		if (divisor < 1)
		{
			throw new ArgumentOutOfRangeException(nameof(divisor), "Divisor must be a positive integer");
		}
		if (_replacements.OfType<DivisibleReplacementRule>().Any(r => r.Divisor == divisor))
		{
			throw new ArgumentException($"A replacement rule already exists for divisor {divisor}");
		}
		
		var method = GetType().GetMethod("ReplaceIfDivisible", BindingFlags.NonPublic | BindingFlags.Instance);
		var replacement = new DivisibleReplacementRule()
		{
			Divisor = divisor,
			MethodInfo = method,
			ReplacementWord = replacementWord
		};
		_replacements.Add(replacement);
	}

	private string ReplaceIfDivisible(int number, DivisibleReplacementRule replacement)
	{
		return number % replacement.Divisor == 0 ? replacement.ReplacementWord : string.Empty;
	}
}