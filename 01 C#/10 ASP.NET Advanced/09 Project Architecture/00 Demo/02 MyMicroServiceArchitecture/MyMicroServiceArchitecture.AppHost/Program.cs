var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.MyMicroServiceArchitecture_ApiService>("apiservice");

builder.AddProject<Projects.MyMicroServiceArchitecture_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.MyMicroServiceArchitecture_Catalog>("mymicroservicearchitecture-catalog");

builder.AddProject<Projects.MyMicroServiceArchitecture_Delivery>("mymicroservicearchitecture-delivery");

builder.Build().Run();
