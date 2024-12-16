using Moq;
using TextFilter.Console.Filters;
using TextFilter.Console.Readers;
using Xunit;

public class TextFilterServiceTests
{
	[Fact]
	public void ApplyFilters_ShouldApplyAllFilters()
	{
		// Arrange
		var mockReader = new Mock<IFileReader>();

		mockReader.Setup(r => r.ReadFile())
			.Returns("clean simple example to test");

		var filters = new IFilter[]
		{
			new MiddleVowelFilter(),
			new LenghtFilter(3),
			new LetterFilter('t')
		};

		var service = new TextFilterService(filters, mockReader.Object);

		// Act
		var result = service.ApplyFilters();

		// Assert
		Assert.Equal("simple example", result);
	}

	[Fact]
	public void ApplyFilters_ShouldHandleEmptyFile()
	{
		// Arrange
		var mockReader = new Mock<IFileReader>();

		mockReader.Setup(r => r.ReadFile())
			.Returns("");

		var filters = new IFilter[]
		{
			new MiddleVowelFilter(),
			new LenghtFilter(3),
			new LetterFilter('t')
		};

		var service = new TextFilterService(filters, mockReader.Object);

		// Act
		var result = service.ApplyFilters();

		// Assert
		Assert.Equal(string.Empty, result);
	}
}