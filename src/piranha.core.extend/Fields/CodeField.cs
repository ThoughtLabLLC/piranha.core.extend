using Piranha.Extend;
using Piranha.Extend.Fields;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Raw Code", Shorthand = "Code", Component = "code-field")]
	public class CodeField : SimpleField<string>
	{
		/// <summary>
		/// Implicit operator for converting a string to a field.
		/// </summary>
		/// <param name="str">The string value</param>
		public static implicit operator CodeField(string str)
		{
			return new CodeField { Value = str };
		}

		/// <summary>
		/// Implicitly converts the Text field to a string.
		/// </summary>
		/// <param name="field">The field</param>
		public static implicit operator string(CodeField field)
		{
			return field.Value;
		}

		/// <summary>
        /// Gets the list item title if this field is used in
        /// a collection regions.
        /// </summary>
        public override string GetTitle()
        {
            if (Value != null)
            {
                return Value.Length > 40 ? Value.Substring(0, 40) + "..." : Value;
            }
            return null;
        }
	}
}
