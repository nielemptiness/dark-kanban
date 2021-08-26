using DarkKanban.Core.Contracts.Interfaces.Database;
using DarkKanban.Core.Contracts.Interfaces.Repositories;
using DarkKanban.Core.Database.Context;
using DarkKanban.Core.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using URF.Core.Abstractions;
using URF.Core.EF;

namespace DarkKanban.Core.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDarkKanbanDataAccess(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql();

            var dbConfig = new DbConfig();
            var section = configuration.GetSection(nameof(DbConfig));
            if (section.Exists())
                section.Bind(dbConfig);
            
            services.AddDbContextPool<DbContext, KanbanDbContext>((serviceProvider, optionBuilder) =>
            {
                optionBuilder.UseNpgsql(dbConfig.ConnectionString,
                opt =>
                {
                    opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    opt.CommandTimeout(60);
                })
                    .UseInternalServiceProvider(serviceProvider);
                NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
            }, poolSize: dbConfig.PoolSize);
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IKanbanDbContext, KanbanDbContext>();
            
            services.AddScoped<IRecordRepository, RecordRepository>();
            services.AddScoped<IColumnRepository, ColumnRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            
            return services;
        }
    }
}