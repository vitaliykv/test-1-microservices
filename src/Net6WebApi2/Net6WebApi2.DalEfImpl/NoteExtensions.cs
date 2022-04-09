using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net6WebApi2.DalCommon;

namespace Net6WebApi2.DalEfImpl
{
	public static class NoteExtensions
	{
        public static WebApplicationBuilder UseNoteDbContext(this WebApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddDbContext<NoteDbContext.NoteDbContext>(options => options.UseNpgsql(connectionString));
            return builder;
        }

        public static WebApplicationBuilder UseNoteSrv(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<INoteSrv, NoteSrv>();
            return builder;
        }
    }
}

