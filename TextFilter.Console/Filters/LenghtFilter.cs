namespace TextFilter.Console.Filters
{
	public class LenghtFilter(int length) : IFilter
	{
		private readonly int _length = length;

		public IEnumerable<string> Apply(IEnumerable<string> input)
		{
			var filteredWords = input.Where(word => word.Length > _length);

			return filteredWords;
		}
	}
}