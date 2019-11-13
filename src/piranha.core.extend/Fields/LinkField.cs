using Piranha.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Thoughtlab.Piranha.Extend.Fields
{
	[FieldType(Name = "Link", Shorthand = "Link", Component = "link-field")]
	public class LinkField : IField
	{
		/// <summary>
		/// Gets or sets the URL.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Determines how the URL should be opened.
		/// </summary>
		public LinkWindowType LinkWindowType { get; set; }

		/// <summary>
		/// Gets or sets the text for the URL.
		/// </summary>
		public string Text { get; set; }

		public string GetTarget()
		{
			switch (LinkWindowType)
			{
				case LinkWindowType.InNewWindow:
					return "_blank";

				default:
					return "";
			}
		}

		string IField.GetTitle()
		{
			return Text;
		}
	}

	/// <summary>
	/// Determines how a <see cref="LinkField"/> should be opened.
	/// </summary>
	public enum LinkWindowType
	{
		/// <summary>
		/// Open the URL in the same tab or window.
		/// </summary>
		None = 0,
		/// <summary>
		/// Open the URL in a tab or window.
		/// </summary>
		[Display(Name = "New window")]
		InNewWindow = 1
	}
}
