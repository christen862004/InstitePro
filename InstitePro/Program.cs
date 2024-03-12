namespace InstitePro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                });//setting middleware
           
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            //----------------------------------------
            app.Run();
        }
    }
}
