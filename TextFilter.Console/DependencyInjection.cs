using Microsoft.Extensions.DependencyInjection;
using TextFilter.Console.Filters;
using TextFilter.Console.Readers;

namespace TextFilter.Console
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddTextFilterServices(this IServiceCollection services)
		{
			services.AddTransient<IFileReader>(provider =>
			{
				string filePath = Global.DefaultInputFile;
				return new FileReader(filePath);
			});

			services.AddTransient<TextFilterService>(provider =>
			{
				var reader = provider.GetRequiredService<IFileReader>();

				var filters = new List<IFilter>
				{
					new MiddleVowelFilter(),
					new LenghtFilter(Global.DefaultLengthValue),
					new LetterFilter(Global.DefaultLetter)
				};

				return new TextFilterService(filters, reader);
			});

			return services;
		}
	}
}
