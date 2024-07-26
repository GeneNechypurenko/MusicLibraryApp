using MusicLibraryApp.Localization.Models;
using static System.Collections.Specialized.BitVector32;

namespace MusicLibraryApp.Localization.Services
{
	public class LangReaderService : ILangReader
	{
		private readonly IConfiguration _config;
		private readonly List<LanguageModel> _languageList;

        public LangReaderService(IConfiguration config)
        {
			_config = config;

			IConfigurationSection localization = _config.GetSection("Localization");
			List<LanguageModel> languages = new List<LanguageModel>();

			foreach (var language in localization.AsEnumerable())
			{
				if (language.Value != null)
				{
					languages.Add(new LanguageModel
					{
						Abbreviation = language.Key.Replace(localization + ":", ""),
						Language = language.Value
					});
				}
			}

			_languageList = languages;
		}
		public List<LanguageModel> LanguageList() => _languageList;
	}
}
