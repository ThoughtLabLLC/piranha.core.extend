using Piranha.Extend;
using Piranha.Extend.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Raw Code", Shorthand = "Code", Component = "code-field")]
	public class CodeField : SimpleField<string>
	{
	}
}
