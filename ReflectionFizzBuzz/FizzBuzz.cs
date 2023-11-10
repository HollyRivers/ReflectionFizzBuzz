namespace ReflectionFizzBuzz; 

public sealed class FizzBuzz {

	public void PrintBetween(int minimum, int maximum) {
		for (var i = minimum; i <= maximum; i++) {
			Print(i);
		}
	}
	
	public void Print(int number) {
		Console.WriteLine(number);
	}
}