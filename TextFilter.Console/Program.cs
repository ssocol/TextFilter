using Microsoft.Extensions.DependencyInjection;
using TextFilter.Console;

class Program
{
	static void Main(string[] args)
	{
		var serviceProvider = new ServiceCollection()
			.AddTextFilterServices()
			.BuildServiceProvider();

		var textFilterService = serviceProvider.GetRequiredService<TextFilterService>();

		var result = textFilterService.ApplyFilters();

		Console.WriteLine(result);
	}
}
