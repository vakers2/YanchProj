using System;
using AutoMapper;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.ViewModels;
using Models.ViewModels.Post;
using Services.Interfaces;
using Services.Services;

namespace Vue2Spa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
                });

            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=Lorem;Trusted_Connection=True;ConnectRetryCount=0";

            var connection = Configuration.GetConnectionString("Default");
            services.AddDbContext<Context>
                (options => options.UseNpgsql(connection, x => x.MigrationsAssembly("DAL")));

            InitializeServices(services);
            InitializeMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        public void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IPostRepository, PostRepository>();
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, GetUserViewModel>();
                cfg.CreateMap<GetUserViewModel, User>();
                cfg.CreateMap<CreateUserViewModel, User>();

                cfg.CreateMap<Post, GetPostViewModel>()
                    .ForMember(d => d.Owner, opt => opt.MapFrom(x => x.Owner.Name))
                    .ForMember(d => d.Id, opt => opt.MapFrom(x => x.PostId));
                cfg.CreateMap<GetPostViewModel, Post>();
                cfg.CreateMap<CreatePostViewModel, Post>();
            });
        }
    }
}
