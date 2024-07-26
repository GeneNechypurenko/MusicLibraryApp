using MusicLibraryApp.Localization.Models;

namespace MusicLibraryApp.Localization.Services
{
	public interface ILangReader
	{
		List<LanguageModel> LanguageList();
	}
}
