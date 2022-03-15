using BV3N92_HFT_2021221.Data;
using BV3N92_HFT_2021221.Logic;
using BV3N92_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BV3N92_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IParliamentLogic, ParliamentLogic>();
            services.AddSingleton<IPartyLogic, PartyLogic>();
            services.AddSingleton<IPartyMemberLogic, PartyMemberLogic>();

            services.AddSingleton<IParliamentRepository, ParliamentRepository>();
            services.AddSingleton<IPartyRepository, PartyRepository>();
            services.AddSingleton<IPartyMemberRepository, PartyMemberRepository>();

            services.AddTransient<DbContext, ParliamentAdministrationDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
