using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using University.Core.Services;
using University.Data.Contexts;
using University.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterType<UniversityDbContext>().AsSelf().InstancePerLifetimeScope();

    container.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
    container.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();

    container.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
    container.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
