using Piranha.Extend;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thoughtlab.Piranha.Extend.Fields
{
	public class LinkField : IField
	{

		public string Url { get; set; }

		public string GetTitle()
		{
			throw new NotImplementedException();
		}
	}
}
