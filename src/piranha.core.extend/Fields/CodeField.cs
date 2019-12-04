using Piranha.Extend;
using System;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = FieldName, Shorthand = "Code", Component = "code-field")]
	public class CodeField : IField, IEquatable<CodeField>
	{
		private const string FieldName = "Raw Code";

		public string Html { get; set; }

		public string Css { get; set; }

		/// <summary>
		/// Gets the list item title if this field is used in
		/// a collection regions.
		/// </summary>
		public string GetTitle() => FieldName;

		public bool Equals(CodeField obj)
		{
			if (obj == null)
			{
				return false;
			}

			return Html == obj.Html && Css == obj.Css;
		}
	}
}
