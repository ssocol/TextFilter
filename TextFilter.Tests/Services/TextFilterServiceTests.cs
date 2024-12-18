using Moq;
using TextFilter.Console;
using TextFilter.Console.Filters;
using TextFilter.Console.Readers;

public class TextFilterServiceTests
{
	[Fact]
	public async Task ApplyFilters_ShouldApplyAllFilters()
	{
		// Arrange
		var mockReader = new Mock<IFileReader>();

		mockReader.Setup(r => r.ReadFileAsync())
			.ReturnsAsync("clean simple example to test");

		var filters = new IFilter[]
		{
			new MiddleVowelFilter(),
			new LenghtFilter(Global.DefaultLength),
			new LetterFilter(Global.DefaultLetter)
		};

		var service = new TextFilterService(filters, mockReader.Object);

		// Act
		var result = await service.ApplyFilters();

		// Assert
		Assert.Equal("simple example", result);
	}

	[Fact]
	public async Task ApplyFilters_ShouldHandleEmptyFile()
	{
		// Arrange
		var mockReader = new Mock<IFileReader>();

		mockReader.Setup(r => r.ReadFileAsync())
			.ReturnsAsync("");

		var filters = new IFilter[]
		{
			new MiddleVowelFilter(),
			new LenghtFilter(Global.DefaultLength),
			new LetterFilter(Global.DefaultLetter)
		};

		var service = new TextFilterService(filters, mockReader.Object);

		// Act
		var result = await service.ApplyFilters();

		// Assert
		Assert.Equal(string.Empty, result);
	}
}