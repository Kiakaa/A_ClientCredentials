using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace A_ClientCredentialsAPI
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvcCore()
                .AddAuthorization()//认证
                .AddJsonFormatters();
            services.AddAuthentication("Bearer")//授权
                                                //.AddOpenIdConnect()//默认值只要OpenId授权方式，
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";//Token颁发者基地址。
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1"; //将有关令牌授权上下文的信息从授权服务器传递到受保护资源。
                });//安装包 IdentityServer4.AccessTokenValidation ，以支持新的认证方式
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
