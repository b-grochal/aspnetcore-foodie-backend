using Foodie.Templates.Factories;
using Foodie.Templates.Renderer;
using Foodie.Templates.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Foodie.Emails
{
    public static class EmailsInstaller
    {
        public static IServiceCollection AddEmails(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRazorPages();
            serviceCollection.AddTransient<IEmailsService, EmailsService>();
            serviceCollection.AddTransient<IEmailMessageFactory, EmailMessageFactory>();
            serviceCollection.AddTransient<IViewsRenderer, ViewsRenderer>();

            return serviceCollection;
        }
    }
}
