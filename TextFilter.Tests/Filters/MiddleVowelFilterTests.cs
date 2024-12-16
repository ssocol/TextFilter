using System.Linq;
using TextFilter.Console.Filters;
using Xunit;

public class MiddleVowelFilterTests
{
	private readonly MiddleVowelFilter _filter;

	public MiddleVowelFilterTests()
	{
		_filter = new MiddleVowelFilter();
	}

	[Fact]
	public void Apply_ShouldFilterOutWordsWithMiddleVowels()
	{
		// Arrange
		var input = new[] { "a", "to", "clean", "rather", "vowel", "begin", "on" };
		var expectedOutput = new[] { "rather", "vowel", "begin" };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldRetainWordsWithoutMiddleVowels()
	{
		// Arrange
		var input = new[] { "by", "sky", "myth", "brink", "crypt", "glyph" };
		var expectedOutput = new[] { "by", "sky", "myth", "crypt", "glyph" };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleSingleCharacterWords()
	{
		// Arrange
		var input = new[] { "a", "e", "i", "o", "u", "b", "c" };
		var expectedOutput = new[] { "b", "c" };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleTwoCharacterWords()
	{
		// Arrange
		var input = new[] { "at", "by", "on", "to", "ab", "cd" };
		var expectedOutput = new[] { "by", "cd" };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleOddLengthWords()
	{
		// Arrange
		var input = new[] { "clean", "seven", "begin", "hello" };
		var expectedOutput = new[] { "seven", "begin", "hello" };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleEvenLengthWords()
	{
		// Arrange
		var input = new[] { "team", "place", "clear", "cool", "good", "keep" };
		var expectedOutput = Array.Empty<string>();

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleEmptyInput()
	{
		// Arrange
		var input = new string[] { };

		// Act
		var result = _filter.Apply(input).ToArray();

		// Assert
		Assert.Empty(result);
	}
}