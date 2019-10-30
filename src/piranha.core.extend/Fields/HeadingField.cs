using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Heading", Shorthand = "Heading", Component = "heading-field")]
	public class HeadingField : SimpleField<string>
	{
		/// <summary>
		/// Gets/sets the heading level.
		/// </summary>
		/// <returns></returns>
		public HeadingFieldLevel HeadingLevel { get; set; }

		/// <summary>
		/// Implicit operator for converting a string to a field.
		/// </summary>
		/// <param name="str">The string value</param>
		public static implicit operator HeadingField(string str)
		{
			return new HeadingField { Value = str };
		}

		/// <summary>
		/// Implicitly converts the Heading field to a string.
		/// </summary>
		/// <param name="field">The field</param>
		public static implicit operator string(HeadingField field)
		{
			return field.Value;
		}
	}

	public enum HeadingFieldLevel
	{
		None = 0,
		H1 = 1,
		H2 = 2,
		H3 = 3,
		H4 = 4,
		H5 = 5,
		H6 = 6
	}
}
