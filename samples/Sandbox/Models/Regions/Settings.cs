using Piranha.AttributeBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiranhaCMSTest.Models.Regions
{
	public class Settings
	{
		[Field(Title = "Navigation Style")]
		public NavigationStyle NavigationStyle { get; set; }
	}

	public enum NavigationStyle
	{
		Light,
		Dark
	}
}
