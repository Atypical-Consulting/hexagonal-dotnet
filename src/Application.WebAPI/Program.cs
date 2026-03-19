using Ideator.API.Modules;
using TheAppManager.Startup;

AppManager.Start(args, modules =>
{
    modules.Add<DomainServicesModule>();
    modules.Add<WebApiModule>();
});
