using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace PiranhaCMSTest.Models.Regions
{
	public class Hero
	{
		[Field(Title = "Background Image")]
		public ImageField BackgroundImage { get; set; }

		[Field(Options = FieldOption.HalfWidth)]
		public TextField Subtitle { get; set; }

		[Field(Options = FieldOption.HalfWidth)]
		public TextField Title { get; set; }
	}
}
