
using ETLDados.Models;
using Microsoft.EntityFrameworkCore;

namespace ETLDados.Data;

public class DefaultContext : DbContext
{
    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {

    }

    public DbSet<Albums> Albums {get; set;}
    public DbSet<Comments> Comments {get; set;}
    public DbSet<Photos> Photos {get; set;}
    public DbSet<Posts> Posts {get; set;}
    public DbSet<Todos> Todos {get; set;}
    public DbSet<Users> Users {get; set;}
    public DbSet<Address> Address {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var posts = new List<Posts>();
        posts.Add(new Models.Posts() {
            Id = 1,
            UserId = 1,
            body = "Teste",
            Title = "Titulo"
        });
        modelBuilder.Entity<Posts>().HasData(posts);

        var comments = new List<Comments>();
        comments.Add(new Models.Comments() {
            Id = 1,
            PostId = 1,
            Body = "Teste",
            Email = "pessoa@gmail.com",
            Name = "Teste"
        });
        modelBuilder.Entity<Comments>().HasData(comments);

        var albuns = new List<Albums>();
        albuns.Add(new Models.Albums() {
            Id = 1,
            Title = "Teste",
            UserId = 1
        });
        modelBuilder.Entity<Albums>().HasData(albuns);

        var fotos = new List<Photos>();
        fotos.Add(new Models.Photos() {
            Id = 1,
            Title = "Teste",
            AlbumId = 1,
            ThumbnailUrl = "http://url.com",
            Url = "http://url.com"
        });
        modelBuilder.Entity<Photos>().HasData(fotos);

        var todos = new List<Todos>();
        todos.Add(new Models.Todos() {
            Id = 1,
            Title = "Teste",
            Completed = false,
            UserId = 1
        });
        modelBuilder.Entity<Todos>().HasData(todos);

        var addresses = new List<Address>();
        addresses.Add(new Models.Address() {
            Id = 1,
            City = "Palmas",
            Street = "Rua teste",
            Suite = "APTO 300",
            ZipCode = "72032653"
        });
        modelBuilder.Entity<Address>().HasData(addresses);

        var users = new List<Users>();
        users.Add(new Models.Users() {
            Id = 1,
            
            Email = "pessoa@gmail.com",
            Name = "João Fulano",
            Phone = "63984653212",
            Username = "pessoa2023",
            Website = "https://www.google.com",
            AddressId = 1
        });
        modelBuilder.Entity<Users>().HasData(users);

        

        base.OnModelCreating(modelBuilder);
    }
}