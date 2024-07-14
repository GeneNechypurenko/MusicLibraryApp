namespace MusicLibraryApp.Models
{
    public class UserViewModel
    {
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsBlocked { get; set; }
    }
}
