using Piranha.Extend;
using Piranha.Extend.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Color Picker", Shorthand = "Color", Component = "color-field")]
	public class ColorField : SimpleField<string>
	{
	}
}
