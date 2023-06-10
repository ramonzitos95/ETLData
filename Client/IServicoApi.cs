using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETLDados.Models;
using Refit;

namespace ETLDados.Client
{
    public interface IServicoApi
    {
        [Get("/posts")]
        public Task<List<Posts>> GetPosts();

        [Get("/comments")]
        public Task<List<Comments>> GetComments();

        [Get("/albums")]
        public Task<List<Albums>> GetAlbums();

        [Get("/photos")]
        public Task<List<Photos>> GetPhotos();

        [Get("/todos")]
        public Task<List<Todos>> GetTodos();

        [Get("/users")]
        public Task<List<Users>> GetUsers();
    }
}