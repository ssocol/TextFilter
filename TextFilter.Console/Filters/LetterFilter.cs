namespace TextFilter.Console.Filters
{
	public class LetterFilter(char letter) : IFilter
	{
		private readonly char _letter = letter;

		public IEnumerable<string> Apply(IEnumerable<string> input)
		{
			var filteredWords = input.Where(word =>
				!word.Contains(_letter, StringComparison.OrdinalIgnoreCase));

			return filteredWords;
		}
	}
}