using MauiApp1.DbApp;
using MauiApp1.DbApp.Database.Repositories.Implementations;
using MauiApp1.DbApp.Database.Repositories.Interfaces;
using MauiApp1.Front.Services;
using MauiApp1.Front.Services.Entity;
using MauiApp1.Front.Services.Jwt;
using MauiApp1.Front.Services.Log;
using MauiApp1.Front.Services.Mapper;
using Microsoft.Extensions.Logging;

namespace MauiApp1.Front
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();


            builder.Services.AddSingleton<HealtechDbContext>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IHashService, HashService>();
            builder.Services.AddSingleton<IJwtTokenService, JwtTokenService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<ILoggingService, NLogLoggingService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
