using System.Text;

namespace ReflectionFizzBuzz; 

public sealed class FizzBuzz {
	private readonly Dictionary<int, string> _replacements = new();

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
			if (number % replacement.Key == 0) {
				output.Append(replacement.Value);
			}
		}
		var result = output.ToString();
		return result == string.Empty ? number.ToString() : result;
	}

	public void AddDivisorReplacementRule(int divisor, string replacementWord) {
		_replacements.Add(divisor, replacementWord);
	}
}