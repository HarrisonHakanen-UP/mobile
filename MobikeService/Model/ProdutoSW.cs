﻿using System;

namespace RestClient.Services
{

    public class ProdutosSW
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public ProdutoSW[] results { get; set; }
    }

    public class ProdutoSW
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public string[] films { get; set; }
        public string[] species { get; set; }
        public string[] vehicles { get; set; }
        public string[] starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }




}