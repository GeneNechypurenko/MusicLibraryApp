using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.UserPage
{
    public class UserCreateViewModel
    {
        public UserModel User { get; set; }
        public TuneModel Tune { get; set; }
        public FilterModel<CategoryDTO> Category { get; set; }
        public UserCreateViewModel(UserModel user, TuneModel tune, FilterModel<CategoryDTO> filter)
        {
            User = user;
            Tune = tune;
            Category = filter;
        }
    }
}
