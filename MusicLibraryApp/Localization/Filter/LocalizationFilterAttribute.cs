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
			string? currentCulture = null;
			string? getCookie = context.HttpContext.Request.Cookies["Localization"];

			if (currentCulture != null)
			{
				currentCulture = getCookie;
			}
			else
			{
				currentCulture = "en";
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
