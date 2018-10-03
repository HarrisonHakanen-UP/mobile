using System;
using System.Collections.Generic;
using System.Text;

namespace RestClient.Model
{
    public class Produto
    {
        public int produtoId { get; set; }
        public string nome { get; set; }
        public string numeroProduto { get; set; }
        public string nivelEstoque { get; set; }
        public string pontoReordenar { get; set; }
        public string custoPadrao { get; set; }
        public string precoVenda { get; set; }
        public string tamanhoProduto { get; set; }
        public string unidadeMedidaTamanho { get; set; }
        public string unidadeMedidaPeso { get; set; }
        public string pesoProduto { get; set; }
        public string diasParaFabricarProduto { get; set; }
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
        public object cor { get; set; }
    }

}