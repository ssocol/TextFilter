namespace TextFilter.Console.Filters
{
	public interface IFilter
	{
		public IEnumerable<string> Apply(IEnumerable<string> text);
	}
}