using Piranha.Extend;

namespace PiranhaCMSTest.Models.Regions
{
	public class Settings
	{
		[Field(Title = "Navigation Style")]
		public NavigationStyle NavigationStyle { get; set; }
	}

	public enum NavigationStyle
	{
		Light,
		Dark
	}
}
