using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using Piranha.Models;
using Piranha.Extend;

namespace PiranhaCMSTest.Web.Models.SiteTypes
{
	[SiteType(Title = "Default Site")]
	public class DefaultSite : SiteContent<DefaultSite>
	{
		[Region]
		public SiteHeader Header { get; set; }

		public class SiteHeader
		{
			[Field]
			public ImageField Logo { get; set; }

			[Field]
			public StringField Title { get; set; }
		}
	}
}
