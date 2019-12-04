using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Piranha;

namespace piranha.manager.extend
{
	public static class ExtendedManagerExtensions
	{
		public static IApplicationBuilder UseExtendedManager(this IApplicationBuilder builder)
		{
			//
			// Register styles
			//
			//App.Modules.Get<Piranha.Manager.Module>().Styles.Add("~/manager/extend/piranha.manager.extend.min.css");

			App.Modules.Get<Piranha.Manager.Module>().Styles.Add("~/manager/extend/codemirror.css");
			App.Modules.Get<Piranha.Manager.Module>().Styles.Add("~/manager/extend/show-hint.css");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/codemirror.js");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/css.js");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/show-hint.js");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/css-hint.js");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/html-hint.js");
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/piranha.manager.extend.min.js");

			//
			// Add the embedded resources
			//
			return builder.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new EmbeddedFileProvider(typeof(ExtendedManagerExtensions).Assembly, "piranha.manager.extend.assets.dist"),
				RequestPath = "/manager/extend"
			});
		}
	}
}
