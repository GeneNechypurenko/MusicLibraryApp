using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MusicLibraryApp.Models.AdminPage
{
	public class AdminTuneViewModel
	{
		public string? Username { get; set; }
		public TuneViewModel? Tune { get; set; }
	}
}
