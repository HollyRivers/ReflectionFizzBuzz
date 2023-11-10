namespace ReflectionFizzBuzz; 

public sealed class FizzBuzz {
	private readonly Dictionary<int, string> _replacements = new();

	public void PrintBetween(int minimum, int maximum) {
		for (var i = minimum; i <= maximum; i++) {
			Print(i);
		}
	}
	
	public void Print(int number) {
		Console.WriteLine(number);
	}

	public void AddDivisorReplacementRule(int divisor, string replacementWord) {
		_replacements.Add(divisor, replacementWord);
	}
}