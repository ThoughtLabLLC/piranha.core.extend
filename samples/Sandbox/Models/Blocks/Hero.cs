using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace PiranhaCMSTest.Web.Models.Blocks
{
	[BlockGroupType(Name = "Hero", Category = "Complex", Icon = "fas fa-image", UseCustomView = true, Component = "complex-block")]
	[BlockItemType(Type = typeof(ImageField))]
	public class Hero : BlockGroup
	{
		//[Field(Title = "Background Image")]
		//public ImageField BackgroundImage { get; set; }

		//[Field(Options = FieldOption.HalfWidth)]
		//public TextField Subtitle { get; set; }

		//[Field(Options = FieldOption.HalfWidth)]
		//public TextField Title { get; set; }
	}
}
