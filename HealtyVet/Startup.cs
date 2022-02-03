using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using HealtyVet.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HealtyVet.DataAccess;
using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Services;
using HealtyVet.ApplicationLogic.Service;

namespace HealtyVet
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<HealtyVetDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();



            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<AppointmentService>();



            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<DoctorService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();


            services.AddScoped<IPetRepository, PetRepository>();


            services.AddScoped<IPetOwnerRepository, PetOwnerRepository>();
            services.AddScoped<PetOwnerService>();



            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<RegisterService>();

            services.AddControllersWithViews();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(services).Wait();

        }
        //user roles
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;

            var roleCheck = await RoleManager.RoleExistsAsync("PetOwner");
            if (!roleCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("PetOwner"));
            }
            //here we are assigning the Admin role to the User that we have registered above 

            IdentityUser user = await UserManager.FindByEmailAsync("user1@gmail.com");
            var User = new IdentityUser();
            await UserManager.AddToRoleAsync(user, "PetOwner");


            roleCheck = await RoleManager.RoleExistsAsync("Doctor");
            if (!roleCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Doctor"));
            }
            //here we are assigning the Admin role to the User that we have registered above 

            IdentityUser user2 = await UserManager.FindByEmailAsync("doctor@gmail.com");
            var User2 = new IdentityUser();
            await UserManager.AddToRoleAsync(user2, "Doctor");

        }

    }
}
