using System.Linq;
using TextFilter.Console.Filters;
using Xunit;

public class LenghtFilterTests
{
	[Fact]
	public void Apply_ShouldFilterOutWordsWithLengthLessThanThree()
	{
		// Arrange
		var filter = new LenghtFilter(2); // Length < 3 (0, 1, 2 should be excluded)
		var input = new[] { "a", "to", "be", "the", "and", "run", "cat" };
		var expectedOutput = new[] { "the", "and", "run", "cat" }; // Words of length >= 3

		// Act
		var result = filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldIncludeWordsWithLengthExactlyThree()
	{
		// Arrange
		var filter = new LenghtFilter(2); // Filter words with length <= 2
		var input = new[] { "sky", "sea", "pie", "a", "an" };
		var expectedOutput = new[] { "sky", "sea", "pie" }; // Words with length exactly 3 are included

		// Act
		var result = filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldRetainLongerWords()
	{
		// Arrange
		var filter = new LenghtFilter(2);
		var input = new[] { "table", "flower", "desk", "chair" };
		var expectedOutput = new[] { "table", "flower", "desk", "chair" }; // All words length >= 3

		// Act
		var result = filter.Apply(input).ToArray();

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldReturnEmpty_WhenAllWordsAreShort()
	{
		// Arrange
		var filter = new LenghtFilter(2);
		var input = new[] { "a", "it", "no" };
		var expectedOutput = new string[] { }; // All words are filtered out

		// Act
		var result = filter.Apply(input).ToArray();

		// Assert
		Assert.Empty(result);
	}

	[Fact]
	public void Apply_ShouldHandleEmptyInput()
	{
		// Arrange
		var filter = new LenghtFilter(2);
		var input = new string[] { };

		// Act
		var result = filter.Apply(input).ToArray();

		// Assert
		Assert.Empty(result);
	}
}