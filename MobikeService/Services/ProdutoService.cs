using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Services
{
    public class ProdutoService : GenericRest<Produtos>
    {
        public ProdutoService() : base("https://swapi.co/api/people/", new HttpClient())
        {
        }
    }
}
