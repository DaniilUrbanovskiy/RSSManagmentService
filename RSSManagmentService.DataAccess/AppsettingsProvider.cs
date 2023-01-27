using Microsoft.Extensions.Configuration;


namespace RSSManagmentService.DataAccess
{
    public static class AppsettingsProvider
    {
        public static IConfigurationRoot GetJsonAppsettingsFile() => new ConfigurationBuilder()
           .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
           .AddJsonFile("appsettings.json", false)
           .Build();
    }
}
