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

	public void PrintBetween_WithValidRange_PrintsListOfNumbersToConsole() {
		var expected = $"1{Environment.NewLine}2{Environment.NewLine}3{Environment.NewLine}4{Environment.NewLine}5{Environment.NewLine}6{Environment.NewLine}" +
		               $"7{Environment.NewLine}8{Environment.NewLine}9{Environment.NewLine}10{Environment.NewLine}11{Environment.NewLine}12{Environment.NewLine}" +
		               $"13{Environment.NewLine}14{Environment.NewLine}15{Environment.NewLine}";
		using var sw = new StringWriter();
		Console.SetOut(sw);
		var sut = new FizzBuzz();

		sut.PrintBetween(1, 15);

		var actual = sw.ToString();
		actual.Should().Be(expected);
	}
}