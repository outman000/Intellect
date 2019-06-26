using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using IntellUser.CLassService;
using IntellUser.InterFace;
using IntellUser.BaseClass;

namespace IntellUser
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //register config file 
            Configuration = setConfig(env, "appsettings.json");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            EFBaseClass.connection = Configuration.GetConnectionString("SqlServerConnection");
          
            var sss = Configuration["tools"];
            //这里注入是为了用ef框架，在control里面就不在就不注入了
            services.AddDbContext<DtolContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));

            var connection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<DtolContext>
                (options =>
                {
                    //sqlServerOptions数据库提供程序级别的可选行为选择器
                    //UseQueryTrackingBehavior 为通用EF Core行为选择器
                    options.UseSqlServer(connection, sqlServerOptions =>
                    {
                        sqlServerOptions.EnableRetryOnFailure();
                        sqlServerOptions.CommandTimeout(60);
                    })
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });



            services.AddScoped<LoginInterface, LoginService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                        {
                            Title = "东疆智慧后勤用户管理接口文档",
                            Description = "用户管理模块接口",
                            Contact = new Contact
                            {
                                Name = "张祎荻",
                                Email = "479663032@qq.com",
                            },
                            Version = "v1"
                        });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录
                var xmlPath = Path.Combine(basePath, "IntellUser.xml");
                c.IncludeXmlComments(xmlPath);
            });

            // 为 Swagger JSON and UI设置xml文档注释路径
        


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            //允许所有的域
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            // app.UseHttpsRedirection();

            //，启用中间件为生成的 JSON 文档和 Swagger UI 提供服务
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "用户管理文档 V1");
                c.RoutePrefix = string.Empty;
            });






            app.UseHttpsRedirection();
            app.UseMvc();
        }




        public IConfiguration setConfig(IHostingEnvironment env, String config)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile(config, optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
