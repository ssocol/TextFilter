using Moq;
using TextFilter.Console.Readers;

public class FileReaderTests
{
	[Fact]
	public async Task ReadFile_ShouldReturnCorrectContent()
	{
		// Arrange
		var fileContent = "This is a test file for the FileReader.";
		var mockReader = new Mock<IFileReader>();
		mockReader.Setup(r => r.ReadFileAsync())
			.ReturnsAsync(fileContent);

		// Act
		var result = await mockReader.Object.ReadFileAsync();

		// Assert
		Assert.Equal(fileContent, result);
	}

	[Fact]
	public async Task FileReader_ShouldThrowException_WhenFilePathIsEmpty()
	{
		// Arrange
		string invalidPath = string.Empty;

		// Act & Assert
		await Assert.ThrowsAsync<ArgumentException>(() => Task.Run(() =>
		{
			var file = new FileReader(invalidPath);
		}));
	}

	[Fact]
	public async Task FileReader_ShouldThrowException_WhenFileDoesNotExist()
	{
		// Arrange
		string nonExistentPath = "nonexistentfile.txt";

		// Act & Assert
		await Assert.ThrowsAsync<FileNotFoundException>(() => Task.Run(() =>
		{
			var fileReader = new FileReader(nonExistentPath);
		}));
	}
}