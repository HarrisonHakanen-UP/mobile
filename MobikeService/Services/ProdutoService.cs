﻿using RestClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Services
{
    public class ProdutoService : GenericRest<Produto>
    {

        public ProdutoService() : base("http://192.168.0.102:3002/produto/listar", new HttpClient())
        {
        }

        
    }
}