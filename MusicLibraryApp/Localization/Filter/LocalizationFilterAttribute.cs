using Microsoft.AspNetCore.Mvc.Filters;
using MusicLibraryApp.Localization.Services;
using System.Globalization;

namespace MusicLibraryApp.Localization.Filter
{
	public class LocalizationFilterAttribute : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context) { }

		public void OnActionExecuting(ActionExecutingContext context)
		{
			string? currentCulture = context.HttpContext.Request.Cookies["Localization"];
			if (string.IsNullOrEmpty(currentCulture))
			{
				currentCulture = "en";
			}
			else
			{
				currentCulture = currentCulture.Replace("Localization:", "");
			}

			List<string> cultures = context.HttpContext.RequestServices.GetRequiredService<ILangReader>()
				.LanguageList().Select(t => t.Abbreviation).ToList()!;

			if (!cultures.Contains(currentCulture))
			{
				currentCulture = "en";
			}

			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(currentCulture);
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(currentCulture);
		}
	}
}
