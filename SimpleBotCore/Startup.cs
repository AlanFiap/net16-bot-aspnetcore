using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SimpleBotCore.Interface;
using SimpleBotCore.Logic;
using SimpleBotCore.Model;
using SimpleBotCore.Services;

namespace SimpleBotCore
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
            services.AddSingleton<SimpleBotUser>();
            IDatabaseSettings set = new DatabaseSettings();


            var a = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            var cong = builder.Build();

            set.ConnectionString = cong["Net16Mongo:ConnectionString"].ToString();
            set.DatabaseName = cong["Net16Mongo:DatabaseName"].ToString();

            services.AddSingleton<ChatService>(settings => new ChatService(set));
            services.AddMvc();

            services.Configure<DatabaseSettings>(
             Configuration.GetSection(nameof(DatabaseSettings)));


            services.AddSingleton<IDatabaseSettings>(sp =>
        sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseMvc();
        }
    }
}
