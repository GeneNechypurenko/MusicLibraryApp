using MusicLibraryApp.BLL.ModelsDTO;
using System.Collections.Generic;

namespace MusicLibraryApp.Models
{
    public class HomePageViewModel
    {
        public LoginViewModel Login { get; set; }
        public RegistrationViewModel Registration { get; set; }
        public FilterViewModel Filter { get; set; }
        public PaginationViewModel Pagination { get; set; }
        public List<TuneViewModel> Tunes { get; set; }

        public HomePageViewModel()
        {
            Login = new LoginViewModel();
            Registration = new RegistrationViewModel();
            Filter = new FilterViewModel(new List<CategoryDTO>(), 0);
            Pagination = new PaginationViewModel(0, 1, 10);
            Tunes = new List<TuneViewModel>();
        }
    }
}
