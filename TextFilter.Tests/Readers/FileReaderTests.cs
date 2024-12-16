using Moq;
using TextFilter.Console;
using TextFilter.Console.Readers;
using Xunit;

public class FileReaderTests
{
	[Fact]
	public void ReadFile_ShouldReturnCorrectContent()
	{
		// Arrange
		var fileContent = "This is a test file for the FileReader.";
		var mockReader = new Mock<IFileReader>();
		mockReader.Setup(r => r.ReadFile()).Returns(fileContent);

		// Act
		var result = mockReader.Object.ReadFile();

		// Assert
		Assert.Equal(fileContent, result);
	}

	[Fact]
	public void FileReader_ShouldThrowException_WhenFilePathIsEmpty()
	{
		// Arrange
		string invalidPath = string.Empty;

		// Act & Assert
		var exception = Assert.Throws<ArgumentException>(() => new FileReader(invalidPath));
		Assert.Equal("File path cannot be null or empty. (Parameter 'filePath')", exception.Message);
	}

	[Fact]
	public void FileReader_ShouldThrowException_WhenFileDoesNotExist()
	{
		// Arrange
		string nonExistentPath = "nonexistentfile.txt";

		// Act & Assert
		Assert.Throws<FileNotFoundException>(() => new FileReader(nonExistentPath));
	}
}