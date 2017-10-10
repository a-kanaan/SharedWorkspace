using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmptyWebApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Welcome to Calculator Service, plese wait while your request is being attended");
                await context.Response.WriteAsync(Environment.NewLine);
                await Task.Delay(1000);
                
                var strLength = context.Request.Query["length"].FirstOrDefault();
                var strWidth = context.Request.Query["width"].FirstOrDefault();

                if(double.TryParse(strLength, out double length) && double.TryParse(strWidth, out double width))
                {
                    await context.Response.WriteAsync($"Rectangle of width: {width} & length: {length} => Area: {width * length}");
                    return;
                }

                throw new InvalidOperationException("Some arguments are missing!");   
            });
        }
    }
}
