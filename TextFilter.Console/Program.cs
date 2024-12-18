using Microsoft.Extensions.DependencyInjection;
using TextFilter.Console;

class Program
{
	static async Task Main(string[] args)
	{
		var serviceProvider = new ServiceCollection()
			.AddTextFilterServices()
			.BuildServiceProvider();

		var textFilterService = serviceProvider.GetRequiredService<TextFilterService>();

		var result = await textFilterService.ApplyFilters();

		Console.WriteLine(result);
	}
}