namespace MusicLibraryApp.Models
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public PaginationViewModel(int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
