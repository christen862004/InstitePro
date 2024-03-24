using InstitePro.Filtters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstitePro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            /*
             1) framwork service  .Net already Register
             2) Framowrok Service .Net not Already register
             3) Custom service not .Net not Regiter 
             */

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric=false;
                options.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<ITIContext>();





            //Global filtter attrinut
            builder.Services.AddControllersWithViews(
                //Boptions=>options.Filters.Add(new HandelErrorAttribute())

                );
            builder.Services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                });//setting middleware

            
            builder.Services.AddDbContext<ITIContext>(
                options => { 
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

           /*Service */

            var app = builder.Build();
            #region inline Middleware
            //app.Use(async (httpContext, next) => {
            //    //write respo
            //    await httpContext.Response.WriteAsync("1- Middleware 1\n");
            //    //call next
            //    await next.Invoke();//--short circle
            //    await httpContext.Response.WriteAsync("1-1 Middleware 1\n");

            //    //---------
            //});
            //app.Use(async (httpContext, next) => {
            //    //write respo
            //    await httpContext.Response.WriteAsync("2- Middleware 2\n");
            //    //call next
            //    await next.Invoke();//--short circle
            //    await httpContext.Response.WriteAsync("2-2 Middleware 2\n");


            //});
            ////Terminate
            //app.Run(async(httpcontext) => { 
            //    await httpcontext.Response.WriteAsync("3- Terminate\n");

            //});
            #endregion

            // Configure the HTTP request pipeline. //Middleware
            if (!app.Environment.IsDevelopment())//lunch setting 
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//request static file js -css-image 
            //css/style/boot.css

            app.UseRouting();//Employee/index(Controller: ,Action:)default mddleware(.7)
            app.UseSession();//default setting "Service"

            app.UseAuthorization();//perssion
            //custom Route nameConvintion Route
            app.MapControllerRoute("Route1", "A1/{name}/{age:int:range(10,50)}/{color?}"
                , new{
                    controller="Route",
                    action="action1"

                });
            //app.MapControllerRoute("Route2", "{contoller=Route}/{action=action2}");

            //map default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            //----------------------------------------
            app.Run();
        }
    }
}
