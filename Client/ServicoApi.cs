using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

namespace ETLDados.Client;

public class ServicoApi
{
    private readonly HttpClient _httpClient;
    public IServicoApi Client { get; }

    public ServicoApi(string url)
    {
         var httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(35),
            BaseAddress = new Uri(url),
        };

        Client = RestService.For<IServicoApi>(httpClient);
    }

}