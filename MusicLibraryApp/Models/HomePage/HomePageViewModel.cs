namespace MusicLibraryApp.Models.HomePage
{
    public class HomePageViewModel
    {
        public PaginationViewModel Pagination { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public UserViewModel User { get; set; }

        public HomePageViewModel()
        {
            Pagination = new PaginationViewModel(0, 1, 10);
            Categories = new List<CategoryViewModel>();
            User = null;
        }
    }
}
