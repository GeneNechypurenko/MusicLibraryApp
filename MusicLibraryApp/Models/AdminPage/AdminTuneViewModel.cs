using Microsoft.Extensions.Diagnostics.HealthChecks;
using MusicLibraryApp.Models.Base;

namespace MusicLibraryApp.Models.AdminPage
{
    public class AdminTuneViewModel
	{
		public string? Username { get; set; }
		public TuneViewModel? Tune { get; set; }
	}
}
