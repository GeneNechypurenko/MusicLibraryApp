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
			string? cultureName = null;

			var cultureCookie = context.HttpContext.Request.Cookies["Localization"];
			if (cultureCookie != null)
				cultureName = cultureCookie;
			else
				cultureName = "en";

			List<string> cultures = context.HttpContext.RequestServices.GetRequiredService<ILangReader>()
									.LanguageList().Select(t => t.Abbreviation).ToList()!;
			if (!cultures.Contains(cultureName))
			{
				cultureName = "en";
			}

			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
		}
	}
}
