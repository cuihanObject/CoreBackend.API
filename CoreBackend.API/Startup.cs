using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreBackend.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;


namespace CoreBackend.API
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //向Container注册MVC: services.AddMvc();
            services.AddMvc();

            //AddTransient的services是每次请求（不是指Http request）都会创建一个新的实例，它比较适合轻量级的无状态的（Stateless）的service。
            //AddScoped的services是每次http请求会创建一个实例。
            //AddSingleton的在第一次请求的时候就会创建一个实例，以后也只有这一个实例，或者在ConfigureServices这段代码运行的时候创建唯一一个实例。
            //services.AddTransient<LocalMailService>();
            //services.AddTransient<IMailService, LocalMailService>();
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //app.UseDeveloperExceptionPage(); 就是一个middleware, 当exception发生的时候, 
        //这段程序就会处理它.而判断env.isDevelopment() 表示,
        //这个middleware只会在Development环境下被调用.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new NLogLoggerProvider());
            //loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                //中间件
                app.UseDeveloperExceptionPage();
            }
            //在正式环境中, 我们遇到exception的时候, 需要捕获并把它记录(log)下来, 
            //这时候我们应该使用这个middleware: Exception Handler Middleware, 我们可以这样调用它:
            else
            {
                app.UseExceptionHandler();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});ConfigureServices

            //使用mvc中间件
            app.UseStatusCodePages();

            app.UseMvc();
        }




    }
}
