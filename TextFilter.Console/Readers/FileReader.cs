using TextFilter.Console.Readers;

public class FileReader : IFileReader
{
	private readonly string _filePath;

	public FileReader(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
		}

		if (!File.Exists(filePath))
		{
			throw new FileNotFoundException($"File not found at path: {filePath}");
		}

		_filePath = filePath;
	}

	public string ReadFile()
	{
		using StreamReader reader = new(_filePath);

		return reader.ReadToEnd();
	}
}
