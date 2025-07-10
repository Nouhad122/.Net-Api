using Autofac;
using Autofac.Extensions.DependencyInjection;
using University.Core.Services;
using University.Data.Contexts;
using University.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterType<UniversityDbContext>().AsSelf().InstancePerLifetimeScope();
    container.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
    container.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
