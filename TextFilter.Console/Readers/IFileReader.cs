namespace TextFilter.Console.Readers
{
	public interface IFileReader
	{
		public Task<string> ReadFileAsync();
	}
}