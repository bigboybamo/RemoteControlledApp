﻿using Microsoft.Extensions.Logging;
using RemoteControlledApp.Interfaces;
using RemoteControlledApp.Services;
using RemoteControlledApp.View;
using RemoteControlledApp.ViewModels;

namespace RemoteControlledApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ICommandService, CommandService>();
            builder.Services.AddSingleton<DropDownDetailPageViewModel>();
            builder.Services.AddSingleton<DropDownDetailPage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}