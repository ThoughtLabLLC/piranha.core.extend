using System.Collections.Generic;
using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace PiranhaCMSTest.Web.Models.Blocks
{
	[BlockType(Name = "Image Gallery", Category = "ThoughtLab", Icon = "fas fa-images", Component = "image-gallery")]
	public class ImageGallery : Block
	{


		//[Field]
		//public IList<ImageField> Images { get; set; }
	}
}
