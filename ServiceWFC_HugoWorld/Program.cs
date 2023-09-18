var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    // Ajout du service Service
    serviceBuilder.AddService<Service>();
    serviceBuilder.AddServiceEndpoint<Service, IService>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Service.svc");

    serviceBuilder.AddService<Connexion>();
    serviceBuilder.AddServiceEndpoint<Connexion, IConnexion>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "/Connexion.svc");

    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();
