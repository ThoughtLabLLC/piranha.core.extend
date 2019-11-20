﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using piranha.manager.extend;
using Piranha;
using Piranha.AspNetCore.Identity.SQLite;
using PiranhaCMSTest.Web.Models.Blocks;
using Thoughtlab.Piranha.Extend.Fields;

namespace PiranhaCMSTest
{
	public class Startup
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="configuration">The current configuration</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// The application config.
		/// </summary>
		public IConfiguration Configuration { get; set; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApi api)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Initialize Piranha
			App.Init(api);

			// Configure cache level
			App.CacheLevel = Piranha.Cache.CacheLevel.Basic;

			App.Fields.Register<HeadingField>();

			// Register custom blocks
			App.Blocks.Register<ImageGallery>();
			App.Blocks.Register<Hero>();

			// Configure custom resources
			App.Modules.Get<Piranha.Manager.Module>().Scripts.Add("~/manager/extend/js/components/fields/heading-field.js");

			app.UseStaticFiles(new StaticFileOptions
			{
				FileProvider = new EmbeddedFileProvider(typeof(MarkerService).Assembly, "piranha.manager.extend.assets.src"),
				RequestPath = "/manager/extend"
			});

			// Build content types
			var pageTypeBuilder = new Piranha.AttributeBuilder.PageTypeBuilder(api)
				.AddType(typeof(Models.BlogArchive))
				.AddType(typeof(Models.StandardPage))
				.AddType(typeof(Models.StartPage));
			pageTypeBuilder.Build()
				.DeleteOrphans();
			var postTypeBuilder = new Piranha.AttributeBuilder.PostTypeBuilder(api)
				.AddType(typeof(Models.BlogPost));
			postTypeBuilder.Build()
				.DeleteOrphans();
			var siteTypeBuilder = new Piranha.AttributeBuilder.SiteTypeBuilder(api)
				.AddType(typeof(Web.Models.SiteTypes.DefaultSite));
			siteTypeBuilder.Build()
				.DeleteOrphans();

			// Configure custom resources
			App.Modules.Get<Piranha.Manager.Module>()
				.Scripts.Add("~/js/manager.js");

			// Register middleware
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UsePiranha();
			app.UsePiranhaManager();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "areaRoute",
					template: "{area:exists}/{controller}/{action}/{id?}",
					defaults: new { controller = "Home", action = "Index" });

				routes.MapRoute(
					name: "default",
					template: "{controller=home}/{action=index}/{id?}");
			});
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLocalization(options =>
				options.ResourcesPath = "Resources"
			);
			services.AddMvc()
				.AddPiranhaManagerOptions()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddPiranha();
			services.AddPiranhaApplication();
			services.AddPiranhaFileStorage();
			services.AddPiranhaImageSharp();
			services.AddPiranhaManager();
			services.AddPiranhaMemoryCache();

			// Setup Piranha & Asp.Net Identity with SQLite
			services.AddPiranhaEF(options =>
				options.UseSqlite(Configuration.GetConnectionString("piranha")));
			services.AddPiranhaIdentityWithSeed<IdentitySQLiteDb>(options =>
				options.UseSqlite(Configuration.GetConnectionString("piranha")));

			// Setup Piranha & Asp.Net Identity with SQL Server
			//
			// services.AddPiranhaEF(options =>
			// options.UseSqlServer(Configuration.GetConnectionString("piranha")));
			// services.AddPiranhaIdentityWithSeed<IdentitySQLServerDb>(options => options.UseSqlServer(Configuration.GetConnectionString("piranha")));
		}
	}
}
