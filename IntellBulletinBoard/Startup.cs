using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutofacSerilogIntegration;
using AutoMapper;
using Dtol;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace IntellBulletinBoard
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //EFBaseClass.connection = Configuration.GetConnectionString("SqlServerConnection");
            var Service = Assembly.Load("Dto.Service");
            var IService = Assembly.Load("Dto.IService");
            var IRepository = Assembly.Load("Dto.IRepository");
            var Repository = Assembly.Load("Dto.Repository");
            var valitorAssembly = Assembly.Load("ViewModel");

            #region





            #endregion




            //var jwtSettings = new JwtSettings();
            //Configuration.Bind("JwtSettings", jwtSettings);

            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = new TokenValidationParameters
            //    {

            //    };
            //});




            #region EFCore
            var connection = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<DtolContext>(options =>
            options.UseSqlServer(connection));
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


            #endregion
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "东疆智慧后勤公告栏管理接口文档",
                    Description = "公告栏管理模块接口",
                    Contact = new Contact
                    {
                        Name = "柴健",
                        Email = "1054254369@qq.com",
                    },
                    Version = "v1"
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录
                var xmlPath = Path.Combine(basePath, "IntellFood.xml");
                var xmlPathModel = Path.Combine(basePath, "ViewModel.xml");
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(xmlPathModel);
            });
            #endregion
            #region AutoMapper

            services.AddAutoMapper(Service);
            #endregion
            #region mvc服务

            services.AddMvc()
                .AddFluentValidation(config => {
                    config.RegisterValidatorsFromAssembly(valitorAssembly);//程序集注入
                    config.RunDefaultMvcValidationAfterFluentValidationExecutes = false;

                })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion
            #region AutoFac

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();

            //   builder


            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖


            builder.RegisterAssemblyTypes(IRepository, Repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();
            //根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IService, Service)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();
            builder.RegisterLogger(autowireProperties: true);
            //将services填充到Autofac容器生成器中
            builder.Populate(services);
            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();
            #endregion
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();

            //}
            // app.UseAuthentication();//启用验证

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "公告栏管理文档 V1");
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
