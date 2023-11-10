using FluentAssertions;

namespace ReflectionFizzBuzz.Tests;

public class FizzBuzzTests {
	[Theory]
	[InlineData(1, "1")]
	[InlineData(2, "2")]
	[InlineData(3, "3")]
	[InlineData(4, "4")]
	[InlineData(5, "5")]
	public void Print_WithValidNumber_PrintsNumberToConsole(int input, string expectedValue) {
		var expectedOutput = $"{expectedValue}{Environment.NewLine}";
		using var sw = new StringWriter();
		Console.SetOut(sw);
		var sut = new FizzBuzz();

		sut.Print(input);

		var actual = sw.ToString();
		actual.Should().Be(expectedOutput);
	}
}