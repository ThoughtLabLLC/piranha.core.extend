using Piranha.Extend;
using Piranha.Extend.Fields;
using System;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Heading", Shorthand = "Heading", Component = "heading-field")]
	public class HeadingField : IField, IEquatable<HeadingField>
	{
		/// <summary>
		/// Gets/sets the heading level.
		/// </summary>
		/// <returns></returns>
		public HeadingFieldLevel HeadingLevel { get; set; }

		/// <summary>
		/// Gets/sets the text value.
		/// </summary>
		/// <returns></returns>
		public string Value { get; set; }

		public bool Equals(HeadingField obj)
		{
			if (obj == null)
			{
				return false;
			}

			return Value == obj.Value && HeadingLevel == obj.HeadingLevel;
		}

		public string GetTitle()
		{
			return Value;
		}

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
