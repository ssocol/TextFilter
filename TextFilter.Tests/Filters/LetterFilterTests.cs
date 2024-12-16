using TextFilter.Console.Filters;

public class LetterFilterTests
{
	[Fact]
	public void Apply_ShouldFilterOutWordsContainingSpecificLetter()
	{
		// Arrange
		var filter = new LetterFilter('e');
		var input = new[] { "these", "words", "exclude", "elements", "pass" };
		var expectedOutput = new[] { "words", "pass" };

		// Act
		var result = filter.Apply(input);

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldRetainWordsWithoutTheLetter()
	{
		// Arrange
		var filter = new LetterFilter('x');
		var input = new[] { "list", "words", "sample" };
		var expectedOutput = input;

		// Act
		var result = filter.Apply(input);

		// Assert
		Assert.Equal(expectedOutput, result);
	}

	[Fact]
	public void Apply_ShouldHandleEmptyInput()
	{
		// Arrange
		var filter = new LetterFilter('a');
		var input = new string[] { };

		// Act
		var result = filter.Apply(input);

		// Assert
		Assert.Empty(result);
	}
}
