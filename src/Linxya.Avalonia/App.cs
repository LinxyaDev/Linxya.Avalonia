namespace Linxya.Avalonia
{
    /// <summary>
    /// Static class for stating the desktop app
    /// </summary>
    public static class App
    {
        /// <summary>
        /// Build the app to a ClassicDesktopStyleApplicationLifetime object
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="args"></param>
        /// <param name="themeVariant"></param>
        /// <param name="shutdownMode"></param>
        /// <returns></returns>
        public static ClassicDesktopStyleApplicationLifetime Build(Func<Window>? callback = null, string[]? args = null, ThemeVariant? themeVariant = null, ShutdownMode shutdownMode = ShutdownMode.OnLastWindowClose)
        {
            ClassicDesktopStyleApplicationLifetime classicDesktopStyleApplicationLifetime = new()
            {
                Args = args,
                ShutdownMode = shutdownMode
            };
            var builder = AppBuilder.Configure<Application>();
            builder
                .UsePlatformDetect()
                .AfterSetup(delegate
                {
                    builder.Instance?.Styles.Add(new SimpleTheme());
                    if (themeVariant != null && builder.Instance != null)
                    {
                        builder.Instance.RequestedThemeVariant = themeVariant;
                    }
                })
                .SetupWithLifetime(classicDesktopStyleApplicationLifetime);

            classicDesktopStyleApplicationLifetime.MainWindow = callback?.Invoke() ?? new Window();
            return classicDesktopStyleApplicationLifetime;
        }


        /// <summary>
        /// Start the desktop app
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="args"></param>
        /// <param name="themeVariant"></param>
        /// <param name="shutdownMode"></param>
        /// <returns></returns>
        public static int Start(Func<Window>? callback = null, string[]? args = null, ThemeVariant? themeVariant = null, ShutdownMode shutdownMode = ShutdownMode.OnLastWindowClose)
        {
            return Build(callback, args, themeVariant, shutdownMode).Start();
        }
    }
}
