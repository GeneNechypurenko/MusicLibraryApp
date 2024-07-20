using MusicLibraryApp.BLL.ModelsDTO;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.Home
{
    public class CreateModel
    {
        public UserDTO User { get; set; }
        public TuneDTO Tune { get; set; }

        [Required(ErrorMessage = "Audio file is required")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Poster is required")]
        public IFormFile Poster { get; set; }
        public FilterModel Filter { get; set; }
    }
}
