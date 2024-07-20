using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Base
{
    public class UserModel
    {
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsBlocked { get; set; }
        public UserModel(UserDTO user)
        {
            Username = user.Username;
            IsAdmin = user.IsAdmin;
            IsAuthorized = user.IsAuthorized;
            IsBlocked = user.IsBlocked;
        }
    }
}
