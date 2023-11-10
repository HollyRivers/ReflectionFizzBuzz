using FluentAssertions;

namespace ReflectionFizzBuzz.Tests;

public class FizzBuzzTests {
	[Fact]
	public void Print_WithValidNumber_PrintsNumberToConsole() {
		var expectedOutput = $"1{Environment.NewLine}";
		using var sw = new StringWriter();
		Console.SetOut(sw);
		var sut = new FizzBuzz();

		sut.Print(1);

		var actual = sw.ToString();
		actual.Should().Be(expectedOutput);
	}
}