using MusicLibraryApp.Localization.Models;

namespace MusicLibraryApp.Localization.Services
{
	public class LangReaderService : ILangReader
	{
		private readonly IConfiguration _config;
		private readonly List<LanguageModel> _languageList;

		public LangReaderService(IConfiguration config)
		{
			string section = "Localization";
			_config = config;

			IConfigurationSection localization = _config.GetSection(section);
			List<LanguageModel> languages = new List<LanguageModel>();

			foreach (var language in localization.AsEnumerable())
			{
				if (language.Value != null)
				{
					languages.Add(new LanguageModel
					{
						Abbreviation = language.Key.Replace(section + ":", ""),
						Language = language.Value
					});
				}
			}

			_languageList = languages;
		}
		public List<LanguageModel> LanguageList() => _languageList;
	}
}
