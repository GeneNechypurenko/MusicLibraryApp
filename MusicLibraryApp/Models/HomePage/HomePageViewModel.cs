using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.HomePage
{
    public class HomePageViewModel
    {
        public UserViewModel User { get; set; }
        public IEnumerable<TuneDTO> Tunes { get; set; }
        public PageViewModel Page { get; set; }
        public FilterViewModel Filter { get; set; }
        public HomePageViewModel(UserViewModel user, IEnumerable<TuneDTO> tunes, PageViewModel page, FilterViewModel filter) 
        {
            User = user;
            Tunes = tunes;
            Page = page;
            Filter = filter;
        }
    }
}
