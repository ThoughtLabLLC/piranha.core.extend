using Piranha.AttributeBuilder;
using Piranha.Models;
using PiranhaCMSTest.Models.Regions;

namespace PiranhaCMSTest.Models
{
    [PageType(Title = "Standard page")]
    public class StandardPage  : Page<StandardPage>
    {
		public StandardPage()
		{
		}

		[Region(Display = RegionDisplayMode.Setting)]
		public Settings PageSettings { get; set; }
	}
}