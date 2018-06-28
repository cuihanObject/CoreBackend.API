﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreBackend.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //向Container注册MVC: services.AddMvc();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //app.UseDeveloperExceptionPage(); 就是一个middleware, 当exception发生的时候, 
        //这段程序就会处理它.而判断env.isDevelopment() 表示,
        //这个middleware只会在Development环境下被调用.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

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

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            //使用mvc中间件
            //app.UseMvc();
        }
    }
}
