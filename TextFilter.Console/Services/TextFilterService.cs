using TextFilter.Console.Filters;
using TextFilter.Console.Readers;

public class TextFilterService(IEnumerable<IFilter> filters, IFileReader reader)
{
	private readonly IEnumerable<IFilter> _filters = filters;

	private readonly IFileReader _reader = reader;

	public string ApplyFilters()
	{
		var text = _reader.ReadFile();

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