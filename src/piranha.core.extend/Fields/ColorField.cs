using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Color Picker", Shorthand = "Color", Component = "color-field")]
	public class ColorField : SimpleField<string>
	{
		/// <summary>
		/// Implicit operator for converting a string to a field.
		/// </summary>
		/// <param name="str">The string value</param>
		public static implicit operator ColorField(string str)
		{
			return new ColorField { Value = str };
		}

		/// <summary>
		/// Implicitly converts the Text field to a string.
		/// </summary>
		/// <param name="field">The field</param>
		public static implicit operator string(ColorField field)
		{
			return field.Value;
		}
	}
}
