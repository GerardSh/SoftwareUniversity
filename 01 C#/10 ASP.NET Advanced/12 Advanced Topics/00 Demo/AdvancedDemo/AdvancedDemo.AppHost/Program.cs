var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AdvancedDemo>("advanceddemo");

builder.Build().Run();
