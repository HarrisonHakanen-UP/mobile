using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Model
{

    public class Produtos
    {
        public Produto[] Property1 { get; set; }
    }

    public class Produto
    {
        public int produtoId { get; set; }
        public string nome { get; set; }
        public string numeroProduto { get; set; }
        public int nivelEstoque { get; set; }
        public int pontoReordenar { get; set; }
        public int custoPadrao { get; set; }
        public int precoVenda { get; set; }
        public string tamanhoProduto { get; set; }
        public string unidadeMedidaTamanho { get; set; }
        public string unidadeMedidaPeso { get; set; }
        public int pesoProduto { get; set; }
        public int diasParaFabricarProduto { get; set; }
        public string linhaDoProduto { get; set; }
        public object classe { get; set; }
        public object estilo { get; set; }
        public object dataDisponivelVenda { get; set; }
        public object dataNaoDisponivelVenda { get; set; }
        public object dataProdutoDescontinuado { get; set; }
        public object dataModificacao { get; set; }
        public object[] fotos { get; set; }
        public object[] revisaos { get; set; }
        public object[] produtoSubCategorias { get; set; }
        public object[] documentos { get; set; }
        public object[] modelos { get; set; }
        public object unidadeMedida { get; set; }
        public string cor { get; set; }
    }
}