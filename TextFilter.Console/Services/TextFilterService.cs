using TextFilter.Console.Filters;
using TextFilter.Console.Readers;

public class TextFilterService(IEnumerable<IFilter> filters, IFileReader reader)
{
	private readonly IEnumerable<IFilter> _filters = filters;

	private readonly IFileReader _reader = reader;

	public async Task<string> ApplyFilters()
	{
		var text = await _reader.ReadFileAsync();

		var words = text
			.Split([' ', '\r', '\n', '\t'], StringSplitOptions.RemoveEmptyEntries)
			.Where(word => !string.IsNullOrEmpty(word));

		foreach (var filter in _filters)
		{
			words = filter.Apply(words);
		}

		return string.Join(' ', words);
	}
}