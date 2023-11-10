using System.Reflection;
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

	[Fact]
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

	[Fact]
	public void AddDivisorReplacementRule_With3AndFizz_AddsOneRule() {
		var sut = new FizzBuzz();

		sut.AddDivisorReplacementRule(3, "Fizz");

		var fieldInfo = typeof(FizzBuzz).GetField("_replacements", BindingFlags.NonPublic | BindingFlags.Instance);
		var actual = (Dictionary<int, MethodInfo>)fieldInfo.GetValue(sut);

		actual.Should().ContainSingle();
	}

	[Fact]
	public void PrintBetween_WithValidRangeAndFizzReplacementRule_Replaces3WithFizzInOutput() {
		var expected = $"1{Environment.NewLine}2{Environment.NewLine}Fizz{Environment.NewLine}4{Environment.NewLine}5{Environment.NewLine}";
		using var sw = new StringWriter();
		Console.SetOut(sw);
		var sut = new FizzBuzz();
		sut.AddDivisorReplacementRule(3, "Fizz");

		sut.PrintBetween(1, 5);

		var actual = sw.ToString();
		actual.Should().Be(expected);
	}

	[Fact]
	public void PrintBetween_WithValidRangeAndFizzAndBuzzReplacementRules_Replaces3WithFizzAnd5WithBuzzInOutput() {
		var expected = $"1{Environment.NewLine}2{Environment.NewLine}Fizz{Environment.NewLine}4{Environment.NewLine}Buzz{Environment.NewLine}Fizz{Environment.NewLine}" +
		               $"7{Environment.NewLine}8{Environment.NewLine}Fizz{Environment.NewLine}Buzz{Environment.NewLine}11{Environment.NewLine}Fizz{Environment.NewLine}" +
		               $"13{Environment.NewLine}14{Environment.NewLine}FizzBuzz{Environment.NewLine}";
		using var sw = new StringWriter();
		Console.SetOut(sw);
		var sut = new FizzBuzz();
		sut.AddDivisorReplacementRule(3, "Fizz");
		sut.AddDivisorReplacementRule(5, "Buzz");
		
		sut.PrintBetween(1, 15);

		var actual = sw.ToString();
		actual.Should().Be(expected);
	}
}