namespace TextFilter.Console.Filters
{
	public class MiddleVowelFilter : IFilter
	{
		private static readonly HashSet<char> _vowelList = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

		public IEnumerable<string> Apply(IEnumerable<string> input)
		{
			return input.Where(word =>
			{
				string middleCharacters = GetMiddleCharacters(word);

				return !middleCharacters.Any(c => _vowelList.Contains(c));
			});
		}

		private string GetMiddleCharacters(string word)
		{
			int length = word.Length;

			if (length == 1)
			{
				return word;
			}

			if (length == 2)
			{
				return word;
			}

			if (length % 2 == 1)
			{
				int middleIndex = length / 2;
				return word[middleIndex].ToString();
			}

			int middleStart = (length / 2) - 1;

			return word.Substring(middleStart, 2);
		}
	}
}