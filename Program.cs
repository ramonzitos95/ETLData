using System.Text.Json.Serialization;
using ETLDados.Client;
using ETLDados.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("MariaDBContext");

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddScoped<DefaultContext>();

builder.Services.AddDbContext<DefaultContext>(
            x => x.UseMySql(connString, ServerVersion.AutoDetect(connString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

var app = builder.Build();

var urlBase = app.Configuration["urlBase"];

async Task<bool> InsertPosts(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado dos posts");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var posts = await servicoApi.Client.GetPosts();

        context.Posts.AddRange(posts);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

async Task<bool> InsertComments(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado dos comments");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var comments = await servicoApi.Client.GetComments();

        context.Comments.AddRange(comments);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

async Task<bool> InsertPhotos(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado das fotos");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var fotos = await servicoApi.Client.GetPhotos();

        context.Photos.AddRange(fotos);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

async Task<bool> InsertAlbuns(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado dos albuns");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var albuns = await servicoApi.Client.GetAlbums();

        context.Albums.AddRange(albuns);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

async Task<bool> InsertTodos(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado dos todos");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var todos = await servicoApi.Client.GetTodos();

        context.Todos.AddRange(todos);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

async Task<bool> InsertUsers(DefaultContext context)
{
    try
    {
        Console.WriteLine("Insert iniciado dos users");
        if(urlBase == null)
            throw new NullReferenceException("URL Esta nula");

        var servicoApi = new ServicoApi(urlBase);
        var users = await servicoApi.Client.GetUsers();

        context.Users.AddRange(users);
        return await context.SaveChangesAsync() > 0;
    }     
    catch(Exception ex)
    {
        Console.WriteLine("Erro ao executar ETL: " + ex.Message);
        Console.WriteLine("Erro maximo executar ETL: " + ex.GetBaseException());
        return false;
    }
}

app.MapGet("/api/teste", () => "Serviço funcionando");

app.MapPost("/api/generateETL", async ([FromServices] DefaultContext context, HttpContext httpContext) =>
{
    await InsertPosts(context);

    await InsertComments(context);

    await InsertPhotos(context);

    await InsertAlbuns(context);

    await InsertTodos(context);

    await InsertUsers(context);

});

app.Run();