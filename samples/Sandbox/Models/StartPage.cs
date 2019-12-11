using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Models;
using Thoughtlab.Piranha.Extend.Fields;

namespace PiranhaCMSTest.Models
{
	[PageType(Title = "Start page")]
	[PageTypeRoute(Title = "Default", Route = "/start")]
	public class StartPage : Page<StartPage>
	{
		public StartPage()
		{
		}

		//[Region(Display = RegionDisplayMode.Content)]
		//public Hero Hero { get; set; }

		[Region(Display = RegionDisplayMode.Content)]
		public HeadingField MyHeading { get; set; }

		[Region(Display = RegionDisplayMode.Setting)]
		public CodeField CodeBlock { get; set; }

		//[Region(ListTitle = "Title")]
		//public IList<Teaser> Teasers { get; set; }
	}
}
